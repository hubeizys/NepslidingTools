using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace NepslidingTools.testModel
{
    class SerPort
    {
       // public delegate string HDDelegate(string sz);
       // HDDelegate pd = new HDDelegate(new Test().Process);
        SerialPort sp1 = new SerialPort();
        public RecvProcessFunc Processfunc;
        public void init_port(string port_name)
        {

            if (sp1.IsOpen == true)//如果打开状态，则先关闭一下
            {
                sp1.Close();
            }
            try
            {
                // 
                sp1.BaudRate = 4800;
                sp1.DataBits = 7;
                sp1.StopBits = StopBits.Two;
                sp1.Parity = Parity.Even;
                sp1.DataReceived += new SerialDataReceivedEventHandler(sp1_DataReceived);
                //准备就绪              
                sp1.DtrEnable = true;
                sp1.RtsEnable = true;
                //设置数据读取超时为1秒
                sp1.ReadTimeout = 10000;
                sp1.PortName = port_name;
                //sp1.PortName = Program.DK;
                sp1.Open();     //打开串口
                if (!sp1.IsOpen) //如果没打开
                {
                    MessageBox.Show("串口没有打开！", "Error");
                    return;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message+ "   " + "请检查端口正常后再接入数据");
            }

        }

        static public string[] CurPorts()
        {
            return SerialPort.GetPortNames();
        }

        public bool port_st()
        {
            return this.sp1.IsOpen;
        }

        #region 内部子函数
        public void CheckPort()
        {
            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str.Length <= 0)
            {
                MessageBox.Show("本机没有接入卡尺！", "Error");
                return;
            }
        }
        #endregion

        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp1.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
            {
                Thread.Sleep(500);
                byte[] byteRead = new byte[sp1.BytesToRead];    //BytesToRead:sp1接收的字符个数

                    try
                    {
                        Byte[] receivedData = new Byte[sp1.BytesToRead];        //创建接收字节数组
                        sp1.Read(receivedData, 0, receivedData.Length);         //读取数据
                        //string text = sp1.Read();   //Encoding.ASCII.GetString(receivedData);
                        sp1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer
                        //这是用以显示字符串
                        //    string strRcv = null;
                        //    for (int i = 0; i < receivedData.Length; i++ )
                        //    {
                        //        strRcv += ((char)Convert.ToInt32(receivedData[i])) ;
                        //    }
                        //    txtReceive.Text += strRcv + "\r\n";             //显示信息
                        //}
                        string strRcv = null;
                        //int decNum = 0;//存储十进制
                        for (int i = 0; i < receivedData.Length; i++) //窗体显示
                        {

                            strRcv += receivedData[i].ToString("X2");  //16进制显示
                        
                    }         
                    Console.WriteLine(string.Format("接收到的数据为 {0}", strRcv));
                   
                    string ss = strRcv;
                    String strnew = ss.Substring(0, 2);
                    int str1 =Convert.ToInt32( ss.Substring(2,2));
                    int str2 =Convert.ToInt32( ss.Substring(4,2));
                    int str3 =Convert.ToInt32( ss.Substring(6,2));
                    string str4 = ss.Substring(8,2);
                    int str5 =Convert.ToInt32( ss.Substring(10,2));
                    int str6 =Convert.ToInt32( ss.Substring(12,2));
                    string  str7 = ss.Substring(14,2);
                    if (str4== ss.Substring(8, 2)) {
                        str4 = ".";
                        string sz = (str1 - 30).ToString() + (str2 - 30).ToString() + (str3 - 30).ToString()+str4 + (str5 - 30).ToString() + (str6 - 30).ToString();
                        if (Convert.ToInt32( sz.Substring(0,1))==0)
                        {
                            sz= (str2 - 30).ToString() + (str3 - 30).ToString() + str4 + (str5 - 30).ToString() + (str6 - 30).ToString();
                        }
                        Processfunc(sz);
                        //Program.txtstr = sz;
                    }
                    
                    //string sz1 = (str2 - 30).ToString();
                    //string sz2 = (str3 - 30).ToString();

                    //string sz4 = (str5 - 30).ToString();
                    //string sz5 = (str6 - 30).ToString();
                    ////string sz6 = (str7 - 30).ToString();
                    //string stt = sz + sz1 + sz2 + sz4 + sz5;
                    //string sdsdf = strnew;
                    //txtReceive.Text += strRcv + "\r\n";
                }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "出错提示");
                        //txtSend.Text = "";
                    }
                }
    }
      

    }
}
