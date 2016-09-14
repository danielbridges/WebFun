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
    }
}