using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Globalization;
using System.Collections;

namespace GUI_Hydrobot
{
    public partial class Form1 : Form
    {

        public static SerialPort mySerialPort = new SerialPort();
        public static string indata;
        public static GMapOverlay markersOverlay = new GMapOverlay("markers");
        public static int MarkerIndex = 0;
        public GMapMarker currentMarker;
        public static ArrayList markerList = new ArrayList();

        //Delegate Signature
        public delegate void delUpdateUIGeneralTextbox(String newText);


        private void init()
        {
            try
            {
                mySerialPort.PortName = Port_Combobox.Text;
                mySerialPort.BaudRate = 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;




                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                mySerialPort.Open();
                Status_Label.Text = "Port Status: Open";
            }
            catch (Exception)
            {
                Status_Label.Text = "Port Status: Error Opening port";
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            String tempdata;
            SerialPort sp = (SerialPort)sender;
            try
            {
                tempdata = sp.ReadLine();
                if (tempdata.Substring(0,3)=="LOC")
                {
                    if (tempdata.Substring(3, 7) != "INVALID")
                    {
                        double tempLat = double.Parse(tempdata.Substring(3, 9), CultureInfo.InvariantCulture);
                        double tempLng = double.Parse(tempdata.Substring(13, 9), CultureInfo.InvariantCulture);
                        string dateTime = tempdata.Substring(25, tempdata.Length - 25);

                        addGMapMarker(tempLat, tempLng,"red", dateTime);
                    }
                    else
                    {
                        General_Textbox.Text = "Invalid Location";
                    }

                    //addGMapMarker(tempLat, tempLng,dateTime);
                    //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(tempLat, tempLng),
               // GMarkerGoogleType.green);
                  //  markersOverlay.Markers.Add(marker);
                   // marker.Tag = tempLat.ToString("F6") + ", " + tempLng.ToString("F6");
                   // gmap.Overlays.Add(markersOverlay);


                   // gmap.OnMarkerClick += new MarkerClick(gMap_OnMarkerClick);
                }
                indata = tempdata;
                //Through this delegate function we update a GUI element from the secondary thread
                delUpdateUIGeneralTextbox DelUpdateUIGeneralTextbox = new delUpdateUIGeneralTextbox(UpdateGeneralTextbox);
                this.General_Textbox.BeginInvoke(DelUpdateUIGeneralTextbox, tempdata);
            }
            catch (Exception)
            {
                //MessageBox.Show("Error Reading data ");
                // throw;
            }



        }
        public void UpdateGeneralTextbox(String newText)
        {
            this.General_Textbox.Text = newText;
        }
        void getAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Port_Combobox.Items.AddRange(ports);
        }

        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();
        }

        private void OpenPort_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Port_Combobox.Text == "")
                {
                    Status_Label.Text = "Port Status: Please Select a COM port.";
                }
                else
                {
                    Status_Label.Text = "Port Status: Closed";
                    init();
                }
            }
            catch (Exception)
            {

            }
        }

        private void ClosePort_btn_Click(object sender, EventArgs e)
        {
            ArrayList templist = markerList;
            //mySerialPort.Close();
            //Status_Label.Text = "Port Status: Closed";
            for (int i=0;i<templist.Count;i++)
            {
                GMapMarker marker1 = (GMapMarker)templist[i];
                General_Textbox.Text += "\r\n" + marker1.Tag;
            }
        }

        public void addGMapMarker(double lat, double lng, String color)
        {
            GMarkerGoogle marker;
            if (color == "green")
            {
                marker = new GMarkerGoogle(new PointLatLng(lat, lng),
                GMarkerGoogleType.green);
            }
            else if (color == "red")
            {
                marker = new GMarkerGoogle(new PointLatLng(lat, lng),
                 GMarkerGoogleType.arrow);
            }
            else
            {
                marker = new GMarkerGoogle(new PointLatLng(lat, lng),
               GMarkerGoogleType.green);
            }
            markersOverlay.Markers.Add(marker);
            marker.Tag = lat.ToString("F6") + ", " + lng.ToString("F6") +String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now) ;
            gmap.Overlays.Add(markersOverlay);
            gmap.Position = marker.Position;
            //map.
            markerList.Add(marker);

            gmap.OnMarkerClick += new MarkerClick(gMap_OnMarkerClick);
        }

        public void addGMapMarker(double lat, double lng, String color, String dateTime)
        {
            GMarkerGoogle marker;
            if (color=="green")
            {
                marker = new GMarkerGoogle(new PointLatLng(lat, lng),
                GMarkerGoogleType.green);
            }
            else if (color=="red")
            {
               marker = new GMarkerGoogle(new PointLatLng(lat, lng),
                GMarkerGoogleType.arrow);
            }
            else
            {
                marker = new GMarkerGoogle(new PointLatLng(lat, lng),
               GMarkerGoogleType.green);
            }
            markersOverlay.Markers.Add(marker);
            marker.Tag = lat.ToString("F6") + ", " + lng.ToString("F6") + " " + dateTime;
            gmap.Overlays.Add(markersOverlay);
            markerList.Add(marker);
            gmap.Position = marker.Position;

            gmap.OnMarkerClick += new MarkerClick(gMap_OnMarkerClick);
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            //removeCommand = new MenuItem("Remove Marker", new EventHandler(removeCommandMethod));
            //command2 = new MenuItem("Your command name 2", new EventHandler(Method2));
            //markerMenu.MenuItems.Add(removeCommand);
            // markerMenu.MenuItems.Add(command2);


            // Initialize map:
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(40.627198, 22.959999);
            
            gmap.Zoom = 14;


            //GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(40.627198, 22.959999),
              GMarkerGoogleType.green);
            marker.Tag = "40.627198, 22.959999 "+ String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);
            markerList.Add(marker);


            gmap.OnMarkerClick += new MarkerClick(gMap_OnMarkerClick);
        }
        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double lat = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                addGMapMarker(lat, lng,"green");
               // GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng),
                //GMarkerGoogleType.green);
                //markersOverlay.Markers.Add(marker);
               // marker.Tag = lat.ToString() + ", " + lng.ToString();
                //gmap.Overlays.Add(markersOverlay);


                //gmap.OnMarkerClick += new MarkerClick(gMap_OnMarkerClick);
                //MarkerIndex++;
            }
        }

        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                currentMarker = item;
                CurrentMarker_Textbox.Text = currentMarker.Tag.ToString();
                //textBox1.Text = currentMarker.Tag.ToString();
                RemoveMarker_btn.Enabled = true;
            }
        }

        private void RemoveMarker_btn_Click(object sender, EventArgs e)
        {
            if (currentMarker != null)
            {
                markersOverlay.Markers.Remove(currentMarker);
                currentMarker = null;
                RemoveMarker_btn.Enabled = false;
                CurrentMarker_Textbox.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MotorA_Left_btn_Click(object sender, EventArgs e)
        {
            if (MotorA_Speed_TextBox.Text!=null)
            {
                if (Convert.ToInt32(MotorA_Speed_TextBox.Text) < 256)
                {
                    mySerialPort.Write("MOTAL" + MotorA_Speed_TextBox.Text + ",");
                }
                else
                {
                    MotorA_Speed_TextBox.Text = "Error";
                }
            }
        }

        private void MotorA_Right_btn_Click(object sender, EventArgs e)
        {
            if (MotorA_Speed_TextBox.Text!=null)
            {
                if (Convert.ToInt32(MotorA_Speed_TextBox.Text) < 256)
                {
                    mySerialPort.Write("MOTAR" + MotorA_Speed_TextBox.Text + ",");
                }
                else
                {
                    MotorA_Speed_TextBox.Text = "Error";
                }
            }
            
        }

        private void Stop_Motors_btn_Click(object sender, EventArgs e)
        {
            mySerialPort.Write("MOTAS,");
        }

        private void MotorB_Right_btn_Click(object sender, EventArgs e)
        {

        }
    }

}
