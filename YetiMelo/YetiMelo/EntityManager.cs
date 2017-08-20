//using system;
//using system.linq;
//using yetimelo.models;

//namespace yetimelo
//{
//    public class entitymanager
//    {
//        melomodelcontainer2 db = new melomodelcontainer2();

//        // folders //
//        // add
//        public void addtofolders(string path, bool music, bool pics, bool video)
//        {
//            var folder = new folders
//            {
//                path = path,
//                music = music,
//                picture = pics,
//                video = video
//            };
//            db.foldersset.add(folder);
//            db.savechanges();
//        }

//        // select
//        public iqueryable selectfromfolders(int id)
//        {
//            if (id != 0)
//            {
//                var query = from b in db.foldersset
//                            where b.id == id
//                            select b;
//                return query;
//            }
//            else
//            {
//                throw new exception("there is no entity with the given id: " + id);
//            }
//        }

//        // update
//        public void updatefromfolders(int id, string newpath, bool newmusic, bool newpicture, bool newvideo)
//        {
//            var rowtoupdate = db.foldersset.find(id);
//            rowtoupdate.path = newpath;
//            rowtoupdate.music = newmusic;
//            rowtoupdate.picture = newpicture;
//            rowtoupdate.video = newvideo;
//            db.savechanges();
//        }

//        // delete 
//        public void deletefromfolders(int id)
//        {
//            if (db.foldersset.find(id) != null)
//            {
//                var row = db.foldersset.find(id);
//                db.foldersset.remove(row);
//                db.savechanges();
//            }
//            else
//            {
//                throw new exception("there is no entity with the given id: " + id);
//            }
//        }

//        // settings //
//        // add
//        public void addtosettings(string category, string extension, bool check)
//        {
//            var setting = new settings
//            {
//                category = category,
//                extension = extension,
//                check = check
//            };
//            db.settingsset.add(setting);
//            db.savechanges();
//        }

//        // select 
//        public iqueryable selectfromsettings(int id)
//        {
//            if (id != 0)
//            {
//                var query = from b in db.settings
//                            where b.id == id
//                            select b;
//                return query;
//            }
//            else
//            {
//                throw new exception("there is no entity with the given id: " + id);
//            }
//        }

//        // update
//        public void updatefromsettings(int id, string newcategory, string newextension, bool newcheck)
//        {
//            var rowtoupdate = db.settingsset.find(id);
//            rowtoupdate.category = newcategory;
//            rowtoupdate.extension = newextension;
//            rowtoupdate.check = newcheck;
//            db.savechanges();
//        }

//        // delete 
//        public void deletefromsettings(int id)
//        {
//            if (db.settingsset.find(id) != null)
//            {
//                var row = db.settingsset.find(id);
//                db.settingsset.remove(row);
//                db.savechanges();
//            }
//            else
//            {
//                throw new exception("there is no entity with the given id: " + id);
//            }
//        }

//        public void truncatetable(string table)
//        {
//            db.database.executesqlcommand("truncate table [" + table + "]");
//        }
//    }
//}
