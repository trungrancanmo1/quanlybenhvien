using Google.Apis.Util;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    [FirestoreData]
    public class Taikhoan
    {
        [FirestoreProperty]
        public string userName { get; set; }
        [FirestoreProperty]
        public string displayName { get; set; }
        [FirestoreProperty]
        public string type { get; set; }
        [FirestoreProperty]
        public string password { get; set; }

        [FirestoreProperty]
        public virtual string position { get; set; }
        [FirestoreProperty]
        public virtual string specialization { get; set; }
        [FirestoreProperty]
        public virtual string credential  { get; set; }
        [FirestoreProperty]
        public virtual string medicalHistory { get; set; }
        [FirestoreProperty]
        public virtual string testingResult { get; set; }
        [FirestoreProperty]
        public virtual string diagnosis { get; set; }
        [FirestoreProperty]
        public virtual Google.Cloud.Firestore.Timestamp regDate { get; set; }
        [FirestoreProperty]
        public virtual string progress { get; set; }


    }

    [FirestoreData]
    public class Admin : Taikhoan {
    }

    [FirestoreData]
    public class Doctor : Taikhoan
    {
        [FirestoreProperty]
        public override string position { get; set; }
        [FirestoreProperty]
        public override string specialization { get; set; }
        [FirestoreProperty]
        public override string credential { get; set; }
    }

    [FirestoreData]
    public class Patient : Taikhoan
    {
        [FirestoreProperty]
        public override string medicalHistory { get; set; }
        [FirestoreProperty]
        public override string testingResult { get; set; }
        [FirestoreProperty]
        public override string diagnosis { get; set; }
        [FirestoreProperty]
        public override Google.Cloud.Firestore.Timestamp regDate { get; set; }
        [FirestoreProperty]
        public override string progress { get; set; }
    }

}