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
using WindowsFormsApp2;
public class CurrentAccount
{
    private static CurrentAccount instance;
    private Taikhoan curAcc;

    private CurrentAccount()
    {
        curAcc = null;
    }

    public static CurrentAccount Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CurrentAccount();
            }
            return instance;
        }
    }

    public Taikhoan GetData()
    {
        return curAcc;
    }

    public void SetData(Taikhoan acc)
    {
        curAcc = acc;
    }
}