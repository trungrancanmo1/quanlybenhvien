using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [FirestoreData]
    internal class Schedule
    {
        [FirestoreProperty]
        public Google.Cloud.Firestore.Timestamp begin { get; set; }

        [FirestoreProperty]
        public Google.Cloud.Firestore.Timestamp end { get; set; }

        [FirestoreProperty]
        public string room { get; set; }

        [FirestoreProperty]
        public string notes { get; set; }

        [FirestoreProperty]
        public string doctor { get; set; }

        [FirestoreProperty]
        public string patient { get; set; }
    }
}
