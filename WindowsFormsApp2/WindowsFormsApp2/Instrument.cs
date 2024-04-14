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
    class Instrument
    {
        [FirestoreProperty]
        public virtual string name { get; set; }
        [FirestoreProperty]
        public virtual string count { get; set; }

        [FirestoreProperty]
        public virtual string dateIn { get; set; }
        [FirestoreProperty]
        public virtual string dateOut { get; set; }
    }

    [FirestoreData]
    class Medical : Instrument

    {
        [FirestoreProperty]
        public override string name { get; set; }
        [FirestoreProperty]
        public override string count { get; set; }
        [FirestoreProperty]
        public override string dateIn { get; set; }
        [FirestoreProperty]
        public override string dateOut { get; set; }

        [FirestoreProperty]
        public string expiry { get; set; }
    }

    [FirestoreData]
    class Equipment : Instrument
    {
        [FirestoreProperty]
        public override string name { get; set; }
        [FirestoreProperty]
        public override string count { get; set; }
        [FirestoreProperty]
        public override string dateIn { get; set; }
        [FirestoreProperty]
        public override string dateOut { get; set; }
        [FirestoreProperty]
        public string dateMaintenance { get; set; }

        [FirestoreProperty]
        public string status { get; set; }
    }
}
