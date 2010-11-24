using System.Windows.Forms;

namespace ResxEditor.Helpers
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResxEditor.Resources.CommonResources));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("logo")));
        }
    }
}