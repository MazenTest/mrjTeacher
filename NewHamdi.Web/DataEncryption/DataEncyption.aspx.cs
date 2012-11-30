using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MyComponent.Security;

public partial class DataEncryption_DataEncyption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        txtToDecrypt.Text = EncryptAndDecrypt.Encrypt(txtToEncrypt.Text, true);
    }
    protected void btnDecrypt_Click(object sender, EventArgs e)
    {
        txtToEncrypt.Text = EncryptAndDecrypt.Decrypt(txtToDecrypt.Text, true);
    }
}
