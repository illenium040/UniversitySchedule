using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI.CustomControllers
{
    public class CancelButton
    {
        private Button _winFormBtn;
        private readonly string _btnText;
        private readonly string _cancelText;
        private bool _isClicked;

        public Action OnCancel;
        public Action OnClick; 
        public CancelButton(Button button)
        {
            _winFormBtn = button;
            _isClicked = false;
            _btnText = _winFormBtn.Text;
            _cancelText = "Отмена";
            _winFormBtn.Click += _winFormBtn_Click;
        }

        public void Click()
        {
            OnClick?.Invoke();
            _winFormBtn.Text = _cancelText;
            _isClicked = true;
        }

        public void Cancel()
        {
            OnCancel?.Invoke();
            _winFormBtn.Text = _btnText;
            _isClicked = false;
        }

        private void _winFormBtn_Click(object sender, EventArgs e)
        {
            if (!_isClicked) Click();
            else Cancel();
        }
    }
}
