using System;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using AdminAudioVideo.CapaAccesoDatos;
using AdminAudioVideo.CapaPresentacion;
using PictureBox = AForge.Controls.PictureBox;

namespace AdminAudioVideo.Componentes
{
    public class ObjectFormWeb
    {
        public HttpWebRequest HttpWebRequest { get; set; }
        public ArregloControl ArregloControl { get; set; }
    }

    public class ArregloControl
    {
        //private Form HostForm;
        private SplitterPanel _hostForm;
        
        private readonly int[] _posLeftElem1 = new[] { 0, 120, 240, 360, 480, 600, 720, 840, 960, 1080, 1200 };
        private readonly int[] _posLeftElem2 = new[] { 50, 170, 290, 410, 530, 650, 770, 890, 1010, 1130, 1250 };
        private readonly int[] _posTopBoton = new[] { 130, 270, 410, 550, 690, 830, 970, 1010, 1150, 1290 };
        private readonly int[] _posTopLabel = new[] { 30, 170, 310, 450, 590, 730, 840, 980, 1020, 1160 };

        public int Index, Col, Row;
        public string Status;
        public Sucursal SucursalAsignada;

        public Button[] Botones;
        public Label Etiqueta;
        public PictureBox VideoEnLinea;

        string urlcam = "";
        string puerto = "";
        string root = "";
        string pass = "";

        public void CrearComponente(SplitterPanel host, int columna, int fila, int indice, Sucursal tmpSucursal)
        {
            _hostForm = host;
            Index = indice;
            Col = columna;
            Row = fila;
            SucursalAsignada = tmpSucursal;

            //Botones = new Button[2];
            
            Etiqueta = AgregarEtiqueta(tmpSucursal.ClaveSucursal);
            VideoEnLinea = new PictureBox();
            _hostForm.Controls.Add(VideoEnLinea);
            VideoEnLinea.Top = _posTopLabel[Row];
            VideoEnLinea.Left = _posLeftElem1[Col];
            VideoEnLinea.Tag = Index;
            VideoEnLinea.Size = new Size(100, 100);
            VideoEnLinea.BorderStyle = BorderStyle.FixedSingle;

            //VideoEnLinea = AgregarVideoSnapshot();
            //Botones[0] = AgregarBoton("Cam.", ClickVideo, 1);
            //Botones[0] = AgregarBoton("Aud.", ClickAudio, 2);
            AgregarVideoSnapshot(urlcam, puerto, root, pass);



        }

/*
        private Button AgregarBoton(string name, EventHandler evento, int orden)
        { 
            Button aButton = new Button();
            _hostForm.Controls.Add(aButton);
            aButton.Top = _posTopBoton[Row];
            aButton.Left = orden == 1 ? _posLeftElem1[Col] : _posLeftElem2[Col];
            aButton.Size = new Size(50, 50);
            aButton.Tag = Index;
            aButton.Text = string.Format("{0} {1}", name, Index);
            aButton.Click += evento;
            return aButton;
        }
*/

        private Label AgregarEtiqueta(string texto)
        {
            Label etiqueta = new Label();
            _hostForm.Controls.Add(etiqueta);
            //etiqueta.Top = _posTopLabel[Row];
            etiqueta.Top = _posTopBoton[Row];
            etiqueta.Left = _posLeftElem1[Col];
            etiqueta.Text = string.Format("{0}", texto);
            etiqueta.Tag = Index;
            etiqueta.TextAlign = ContentAlignment.MiddleCenter;
            etiqueta.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            
            return etiqueta;
        }

        private void AgregarVideoSnapshot(string Host, string Port, string User, String Passwd)
        {
            //PictureBox imageControl = new PictureBox();
            //_hostForm.Controls.Add(imageControl);
            //imageControl.Top = _posRowLabel[Row];
            //imageControl.Left = _posElem1[Col];
            //imageControl.Tag = Index;
            //imageControl.Size = new Size(100, 100);
            //imageControl.BorderStyle = BorderStyle.FixedSingle;

            HttpWebRequest httpWebRequest;
            try
            {

                string _url = "http://" + Host + ":" + Port + "/cgi-bin/viewer/video.jpg";

                httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                httpWebRequest.PreAuthenticate = true;

                ICredentials icredentials = new System.Net.NetworkCredential(User, Passwd);
                httpWebRequest.Credentials = icredentials;

                ObjectFormWeb objectFormWeb = new ObjectFormWeb();
                objectFormWeb.HttpWebRequest = httpWebRequest;
                objectFormWeb.ArregloControl = this;

                IAsyncResult result = httpWebRequest.BeginGetResponse(new AsyncCallback(ImagenSnapshot), objectFormWeb);
                /*WebResponse webResponse = httpWebRequest.GetResponse();

                if (webResponse.GetResponseStream() != null)
                {
                    Image image = Image.FromStream(webResponse.GetResponseStream());


                    Bitmap img_temp = new Bitmap(imageControl.Width, imageControl.Height);
                    img_temp.SetResolution(image.Width, image.Height);
                    Graphics graphics = Graphics.FromImage(img_temp);
                    graphics.DrawImage(image, 0, 0, imageControl.Width, imageControl.Height);
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

                    graphics.Dispose();
                    imageControl.Image = img_temp;
                }
                webResponse.Close();*/

            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR:" + error.Message);
            }
        }

        private void ImagenSnapshot(IAsyncResult asyncResult)
        {
            try
            {
                Console.WriteLine("Iniciado");
                ObjectFormWeb objectFormWeb = (ObjectFormWeb)asyncResult.AsyncState;
                HttpWebRequest httpWebRequest = objectFormWeb.HttpWebRequest;
                WebResponse webResponse = (HttpWebResponse) httpWebRequest.EndGetResponse(asyncResult);
                if (webResponse.GetResponseStream() != null)
                {
                    PictureBox imageControl = new PictureBox();
                    imageControl.Size = new Size(100, 100);
                    imageControl.BorderStyle = BorderStyle.FixedSingle;
                    
                    Image image = Image.FromStream(webResponse.GetResponseStream());

                    Bitmap img_temp = new Bitmap(imageControl.Width, imageControl.Height);
                    img_temp.SetResolution(image.Width, image.Height);
                    Graphics graphics = Graphics.FromImage(img_temp);
                    graphics.DrawImage(image, 0, 0, imageControl.Width, imageControl.Height);
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

                    graphics.Dispose();
                    imageControl.Image = img_temp;

                    ArregloControl control = objectFormWeb.ArregloControl;
                    control.VideoEnLinea.Image = imageControl.Image;
                    control.VideoEnLinea.Refresh();
                    //objectFormWeb.Imagen = imageControl;
                    //Console.WriteLine("Finalizado " + objectFormWeb.Index);

                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                //throw(exception);
            }
        }

        private void ClickVideo(Object sender, EventArgs e)
        {
            //TODO implementar elementos DAO para almacenar los datos de todos las sucursales
            PanelDetalles detalle = new PanelDetalles(string.Format("Sucursal {0}", Index));
            detalle.Show();
        }

        private void ClickAudio(Object sender, EventArgs e)
        {
            //TODO implementar metodos para obtener audio de la sucursal
        }
    }
}
