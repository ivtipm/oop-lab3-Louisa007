using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot_test1
{
    public partial class LoginForm : Form
    {
        string S_Exit, S_Quest, S_Enter, S_Title; //Текст для labelRef
        int tbxLoginMode; //Переменная для TextBoxLogin

        public LoginForm()
        {
            InitializeComponent();

            S_Exit = "Вы что, уже хотите выйти? Так быстро??? :("; //"Уже хотите выйти?";
            S_Quest = "Введите свой логин, или придумайте новый";
            S_Enter = "Да! Давайте скорее начнём 'диалог'!!! :)";
            S_Title = "Привет! Я твой новый Чат-бот";

            tbxLoginMode = 0;
        }

        //Указатель входит в область "заголовочного Label"
        private void labelTitle_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.DarkOrchid;
            labelTitle.ForeColor = Color.DarkOrchid;
            labelRef.Text = S_Title;
            labelRef.Visible = true;
        }
        //Указатель выходит из области "заголовочного Label"
        private void labelTitle_MouseLeave(object sender, EventArgs e)
        {
            labelRef.Visible = false;
            labelTitle.ForeColor = Color.PaleTurquoise;
        }

        //Указатель входит в область кнопки "Справка"
        private void buttonRef_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.MediumBlue;
            labelTitle.ForeColor = Color.MediumBlue;
            labelRef.Text = S_Quest;
            labelRef.Visible = true;
        }
        //Указатель выходит из области кнопки "Справка"
        private void buttonRef_MouseLeave(object sender, EventArgs e)
        {
            labelRef.Visible = false;
            labelTitle.ForeColor = Color.PaleTurquoise;
        }
        //Нажали на кнопку "Справка"
        private void buttonRef_Click(object sender, EventArgs e)
        {
            string txt_msgbx = "Чат-бот" + "\r\n" +
                "Версия 2.0" + "\r\n" +
                "Добавлено 13 новых команд" + "\r\n" +
                "Ответы на старые вопросы расширены" + "\r\n" +
                "ZabGU|IVT18 Foundation" + "\r\n" +
                "2020" + "\r\n" +
                "---------------------------------------------------------------------" + "\r\n" +
                "На этой форме нужно ввести логин и нажать 'Войти' или ENTER" + "\r\n" +
                "Если логин уже был введён ранее - откроется файл со старой перепиской" + "\r\n" +
                "Если логин новый, то программа создаст новый файл переписки";
            string ttl_msgbx = "Чат-бот 2.0";
            var ok_msgbx = MessageBox.Show(txt_msgbx, ttl_msgbx, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //Указатель входит в область кнопки "Выход"
        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.Brown;
            labelTitle.ForeColor = Color.Brown;
            labelRef.Text = S_Exit;
            labelRef.Visible = true;
        }
        //Указатель выходит из области кнопки "Выход"
        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            labelRef.Visible = false;
            labelTitle.ForeColor = Color.PaleTurquoise;
        }
        //Нажали на кнопку "Выход"
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Указатель входит в область кнопки "Войти"
        private void buttonEnter_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.DarkCyan;
            labelTitle.ForeColor = Color.DarkCyan;
            labelRef.Text = S_Enter;
            labelRef.Visible = true;
        }
        //Указатель выходит из области кнопки "Войти"
        private void buttonEnter_MouseLeave(object sender, EventArgs e)
        {
            labelRef.Visible = false;
            labelTitle.ForeColor = Color.PaleTurquoise;
        }
        //Нажали на кнопку "Войти"
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if((TextBoxLogin.Text == "")||(tbxLoginMode==0))
            {
                string txt_msgbx = "Кажется вы не ввели логин!" + "\r\n" + "Введите его";
                string ttl_msgbx = "Ошибка при входе";
                var ok_msgbx = MessageBox.Show(txt_msgbx, ttl_msgbx, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(ok_msgbx == DialogResult.OK)
                {
                    tbxLoginMode = 0;
                    TextBoxLogin.ForeColor = Color.LightGray;
                    TextBoxLogin.Text = "Логин";
                }
            }
            else
            {
                ChatForm form = new ChatForm();
                form.bot.LoadHistory(TextBoxLogin.Text);
                form.lblCurrentUserLogin.Text = TextBoxLogin.Text;
                form.Show();
                form.RestoreChat();
                Hide();
            }
        }

        //Кликнули по текстбоксу для ввода логина - Серая надпись "Логин" исчезла
        private void TextBoxLogin_Click(object sender, EventArgs e)
        {
            if (tbxLoginMode == 0)
            {
                TextBoxLogin.ForeColor = Color.Black;
                TextBoxLogin.Text = "";
                tbxLoginMode = 1;
            }
        }
    }
}
