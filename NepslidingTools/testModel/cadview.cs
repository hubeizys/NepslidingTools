﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyCAD.Platform;
using AnyCAD.Presentation;

namespace NepslidingTools
{
    class CadView: AnyCAD.Platform.TopoShapeReaderContext
    {
        private AnyCAD.Presentation.RenderWindow3d renderView = null;
        //private Stack<System.Windows.Forms.TreeNode> nodeStack = new Stack<System.Windows.Forms.TreeNode>();
        private int nShapeCount = 100;
        private FaceStyle faceStyle;
        private System.Collections.Generic.Dictionary<int, FaceStyle> faceStyleDict = new System.Collections.Generic.Dictionary<int, FaceStyle>();
        public CadView(AnyCAD.Presentation.RenderWindow3d _renderView)
        {
            renderView = _renderView;
            faceStyle = new FaceStyle();
            //nodeStack.Push(node);
        }

        public override void OnSetFaceColor(ColorValue clr)
        {
            Console.WriteLine(clr.ToRGBA());
            if (clr.ToRGBA() == faceStyle.GetColor().ToRGBA())
                return;

            if (!faceStyleDict.TryGetValue(clr.ToRGBA(), out faceStyle))
            {
                faceStyle = new FaceStyle();
                faceStyle.SetColor(clr);
                faceStyleDict.Add(clr.ToRGBA(), faceStyle);
            }
        }

        public override void OnBeginGroup(String name)
        {
            if (name.Length == 0)
            {
                name = "<UNKNOWN>";
            }

            //if (nodeStack.Count == 0)
            //{
            //    //System.Windows.Forms.TreeNode node = treeView.Nodes.Add(name);
            //    nodeStack.Push(node);
            //}
            //else
            //{
            //    nodeStack.Push(nodeStack.Peek().Nodes.Add(name));
            //}
        }

        public override void OnEndGroup()
        {
            //nodeStack.Pop();
        }

        public override bool OnBeiginComplexShape(TopoShape shape)
        {
        //    nodeStack.Push(nodeStack.Peek().Nodes.Add(String.Format("{0}", nShapeCount), "Shape"));
            return true;
        }

        public override void OnEndComplexShape()
        {
            //nodeStack.Pop();
        }

        public override void OnFace(TopoShape shape)
        {
            ++nShapeCount;
            //nodeStack.Peek().Nodes.Add(String.Format("{0}", nShapeCount), "Face");
            SceneNode node = renderView.ShowGeometry(shape, nShapeCount);
            node.SetFaceStyle(faceStyle);
        }
    }
}
