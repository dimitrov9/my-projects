using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karavas_Stock_Management
{

    public class ElementTypeLabel : Label
    {
        private bool mGrowing;
        public ElementTypeLabel(int ElementTypeID)
        {
            this.AutoSize = false;
            Text = SQLControl.ElementTypeFromID(ElementTypeID).Trim();
            TextAlign = ContentAlignment.TopCenter;
            Font = new Font("Microsoft Sans Serif", 14);
            Location = new Point(5, 161);
            //Anchor = AnchorStyles.Left & AnchorStyles.Top & AnchorStyles.Right;
            Size = new Size(155, 23);
        }
        private void resizeLabel()
        {
            if (mGrowing) return;
            try
            {
                mGrowing = true;
                Size sz = new Size(this.Width, Int32.MaxValue);
                sz = TextRenderer.MeasureText(this.Text, this.Font, sz, TextFormatFlags.WordBreak);
                this.Height = sz.Height+2;
            }
            finally
            {
                mGrowing = false;
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            resizeLabel();
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            resizeLabel();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            resizeLabel();
        }
    }
}
