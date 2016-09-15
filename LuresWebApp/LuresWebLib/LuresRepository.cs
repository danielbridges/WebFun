namespace LuresWebLib
{
    using System.Collections.Generic;
    using Domain;

    public class LuresRepository: BaseRepository<List<Lure>>
    {
        //#region Mock Data to be replaced by calls to a data store
        //private List<Lure> dummyTackleBox = new List<Lure>
        //{
        //    new Lure
        //    {
        //        Id = 1,
        //        ImageUrl = @"~/content/images/img_4930.jpg",
        //        Inventory = 0,
        //        Caught = 0
        //    },
        //    new Lure
        //    {
        //        Id = 2,
        //        ImageUrl = @"~/content/images/img_4931.jpg",
        //        Inventory = 0,
        //        Caught = 0
        //    },
        //    new Lure
        //    {
        //        Id = 3,
        //        ImageUrl = @"~/content/images/img_4934.jpg",
        //        Inventory = 0,
        //        Caught = 0
        //    },
        //    new Lure
        //    {
        //        Id = 4,
        //        ImageUrl = @"~/content/images/img_4935.jpg",
        //        Inventory = 0,
        //        Caught = 0
        //    },
        //    new Lure
        //    {
        //        Id = 5,
        //        ImageUrl = @"~/content/images/img_4936.jpg",
        //        Inventory = 0,
        //        Caught = 0
        //    },
        //};
        //#endregion

        private List<Lure> TackleBox
        {
            get { return Get(); }
        } 
        public Lure Get(int lureId)
        {
            return TackleBox.Find(lure => lure.Id == lureId);
        }

        public List<Lure> Get()
        {
            return Load();
        }

        public int UpdateCaught(int lureId, int incrementValue)
        {
            var result = TackleBox.Find(lure => lure.Id == lureId);
            result.Caught = incrementValue;
            Save(TackleBox);
            return result.Caught;
        }
        public int UpdateInventory(int lureId, int incrementValue)
        {
            var result = TackleBox.Find(lure => lure.Id == lureId);
            result.Inventory += incrementValue;
            return result.Inventory;
        }

        public LuresRepository() : base(@"//Lures.xml")
        {
        }

        //void SaveImage(string pic)
        //{
        //    string query = "insert into Table (Photo) values (@pic);";
        //    string conString = @" Data Source = \Program Files\Users.s3db ";
        //    SQLiteConnection con = new SQLiteConnection(conString);
        //    SQLiteCommand cmd = new SQLiteCommand(query, con);
        //    cmd.Parameters.Add("@pic", DbType.String);
        //    con.Open();
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception exc1)
        //    {
        //        MessageBox.Show(exc1.Message);
        //    }
        //    con.Close();
        //}
        //public void ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        // Convert Image to byte[]
        //        image.Save(ms, format);
        //        byte[] imageBytes = ms.ToArray();

        //        // Convert byte[] to Base64 String
        //        string base64String = Convert.ToBase64String(imageBytes);
        //        SaveImage(base64String);
        //    }
        //}

        //string LoadImage()
        //{
        //    string query = "select Photo from Table;";
        //    string conString = @" Data Source = \Program Files\Users.s3db ";
        //    SQLiteConnection con = new SQLiteConnection(conString);
        //    SQLiteCommand cmd = new SQLiteCommand(query, con);
        //    string base64EncodedImage = null;
        //    con.Open();
        //    try
        //    {
        //        IDataReader reader = cmd.ExecuteReader();
        //        reader.Read(); // advance the data reader to the first row
        //        base64EncodedImage = (string)reader["Photo"];
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    con.Close();
        //    return base64EncodedImage;
        //}

    }

}


