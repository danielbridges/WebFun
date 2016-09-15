namespace LuresWebLib
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using Dapper;
    using Domain;
    using Installers;

    public class LuresRepository//: IRepository<Lure>
    {
        private readonly string connectionString;
        private const string SelectLures = "SELECT Id, ImageUrl, RawImage, Caught, Inventory FROM Lures";
        private const string UpdateLures = "UPDATE Lures Set Caught =  @Caught, Inventory = @Inventory WHERE Id = @Id";

        public LuresRepository(IConnectionStringFactory connectionStringFactory)
        {
            this.connectionString = connectionStringFactory.GetConnectionString("LuresConnectionString");
        }

        //public LuresRepository() : base(@"//Lures.xml")
        //{
        //}

        public Lure Get(int lureId)
        {
            return Get().ToList().Find(lure => lure.Id == lureId);
        }

        public IEnumerable<Lure> Get()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Lure>(SelectLures);
                connection.Close();
                return result;
            }
        }

        public void UpdateCaught(int lureId, int incrementValue)
        {
            var result = Get(lureId);
            result.Caught = incrementValue;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Query<Lure>(UpdateLures,
                    new
                    {
                        Caught = incrementValue,
                        Inventory = result.Inventory,
                        Id = result.Id
                    });
            }
        }

        public void UpdateInventory(int lureId, int incrementValue)
        {
            var result = Get(lureId);
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Query<Lure>(UpdateLures,
                    new
                    {
                        Caught = result.Caught,
                        Inventory = incrementValue,
                        Id = result.Id
                    });
            }
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


