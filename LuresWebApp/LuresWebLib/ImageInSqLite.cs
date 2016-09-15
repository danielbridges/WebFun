namespace ImagenSQLite
{

    //public partial class Form1 : Form
    //{
    //    public Form1()
    //    {
    //        InitializeComponent();
    //        MediaTypeNames.Image photo = new Bitmap(@"\Photos\Image20120601_1.jpeg");
    //        byte[] pic = ImageToByte(photo, System.Drawing.Imaging.ImageFormat.Jpeg);
    //        SaveImage(pic);
    //        LoadImage();
    //    }

    //    public byte[] ImageToByte(MediaTypeNames.Image image, System.Drawing.Imaging.ImageFormat format)
    //    {
    //        using (MemoryStream ms = new MemoryStream())
    //        {
    //            // Convert Image to byte[]
    //            image.Save(ms, format);
    //            byte[] imageBytes = ms.ToArray();
    //            return imageBytes;
    //        }
    //    }
    //    //public Image Base64ToImage(string base64String)
    //    public MediaTypeNames.Image ByteToImage(byte[] imageBytes)
    //    {
    //        // Convert byte[] to Image
    //        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
    //        ms.Write(imageBytes, 0, imageBytes.Length);
    //        MediaTypeNames.Image image = new Bitmap(ms);
    //        return image;
    //    }
    //    /***************** SQLite **************************/
    //    void SaveImage(byte[] imagen)
    //    {
    //        string conStringDatosUsuarios = @" Data Source = \Program Files\GPS___CAM\Data\DatosUsuarios.s3db ";
    //        SQLiteConnection con = new SQLiteConnection(conStringDatosUsuarios);
    //        SQLiteCommand cmd = con.CreateCommand();
    //        cmd.CommandText = String.Format("INSERT INTO Empleados (Foto) VALUES (@0);");
    //        SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
    //        param.Value = imagen;
    //        cmd.Parameters.Add(param);
    //        con.Open();

    //        try
    //        {
    //            cmd.ExecuteNonQuery();
    //        }
    //        catch (Exception exc1)
    //        {
    //            MessageBox.Show(exc1.Message);
    //        }
    //        con.Close();
    //    }
    //    void LoadImage()
    //    {
    //        string query = "SELECT Photo FROM Table WHERE ID='5';";
    //        string conString = @" Data Source = \Program Files\Users.s3db ";
    //        SQLiteConnection con = new SQLiteConnection(conString);
    //        SQLiteCommand cmd = new SQLiteCommand(query, con);
    //        con.Open();
    //        try
    //        {
    //            IDataReader rdr = cmd.ExecuteReader();
    //            try
    //            {
    //                while (rdr.Read())
    //                {
    //                    byte[] a = (System.Byte[])rdr[0];
    //                    pictureBox1.Image = ByteToImage(a);
    //                }
    //            }
    //            catch (Exception exc) { MessageBox.Show(exc.Message); }
    //        }
    //        catch (Exception ex) { MessageBox.Show(ex.Message); }
    //        con.Close();
    //    }
    //}
}