using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot_test1
{
    public partial class ChatForm : Form
    {
        string S_Exit, S_Quest, S_Title, S_LogOut, S_SendMsg, S_ClearAll; //Текст для labelRef
        int tbxMsgMode; //Переменная для TextBoxSendMsg

        public ChatBot bot = new ChatBot();

        public ChatForm()
        {
            InitializeComponent();

            S_Exit =   "Уже хотите уйти? Ну ладно. Надеюсь ещё увидимся )";
            S_Title =  "Введите своё сообщение в нижнее поле, и я постараюсь вам ответить! )";
            S_Quest =  "Отправьте сообщение 'Помощь' и я покажу список доступных вопросов и команд";
            S_LogOut = "Хотите выйти из этого профиля и зайти под другим? :D";
            S_SendMsg = "Да! Нажмите сюда [или нажмите ENTER] и отправьте уже мне ваше сообщение! )";
            S_ClearAll = "Нажав на эту кнопку вы очистите всю переписку!!! Аккуратнее )";

            tbxMsgMode = 0;
            TextBoxSendMsg.ReadOnly = true;
        }

        //Возвращает "вспомогательный Label" бота в исходное состояние
        private void LabelsTxtClr_Default()
        {
            labelTitle.ForeColor = Color.PaleTurquoise;
            labelRef.ForeColor = Color.PaleTurquoise;
            labelRef.Text = "...";
        }

        //Указатель входит в область кнопки "Справка"
        private void buttonRef_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.MediumBlue;
            labelTitle.ForeColor = Color.MediumBlue;
            labelRef.Text = S_Quest;
        }

        //Указатель выходит из области кнопки "Справка"
        private void buttonRef_MouseLeave(object sender, EventArgs e)
        {
            LabelsTxtClr_Default();
        }

        //Указатель входит в область кнопки "Выход"
        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.Brown;
            labelTitle.ForeColor = Color.Brown;
            labelRef.Text = S_Exit;
        }

        //Указатель выходит из области кнопки "Выход"
        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            LabelsTxtClr_Default();
        }

        //Нажатие на кнопку "Выход"
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Выйти из текущего профиля - вернуться на экран входа
        private void buttonUserLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        //Указатель входит в область кнопки "Выйти из профиля"
        private void buttonUserLogout_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.Teal;
            labelTitle.ForeColor = Color.Teal;
            labelRef.Text = S_LogOut;
        }

        //Указатель выходит из области кнопки "Выйти из профиля"
        private void buttonUserLogout_MouseLeave(object sender, EventArgs e)
        {
            LabelsTxtClr_Default();
        }

        //Указатель входит в область "заголовочного Label"
        private void labelTitle_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.DarkOrchid;
            labelTitle.ForeColor = Color.DarkOrchid;
            labelRef.Text = S_Title;
        }

        //Указатель выходит из области "заголовочного Label"
        private void labelTitle_MouseLeave(object sender, EventArgs e)
        {
            LabelsTxtClr_Default();
        }

        //Клик по текстбоксу для отправки сообщений
        private void TextBoxSendMsg_Click(object sender, EventArgs e)
        {
            if ((TextBoxSendMsg.Text == "Напишите сообщение...")&&((tbxMsgMode == 0)||(tbxMsgMode == 1)))
            {
                tbxMsgMode = 1;
                TextBoxSendMsg.SelectionStart = 0;
                TextBoxSendMsg.ReadOnly = true;
            }
        }

        //Пользователь нажимает клавишу в текстбоксе для отправки сообщений
        private void TextBoxSendMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Если текстбокс находится в "начальном состоянии"
            if ((tbxMsgMode == 1) && (TextBoxSendMsg.Text == "Напишите сообщение..."))
            {
                //И Если пользователь нажал клавишу НЕBackspace и НЕDelete, то текстбокс разблокируется
                if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
                {
                    tbxMsgMode = 2;
                    TextBoxSendMsg.ReadOnly = false;
                    TextBoxSendMsg.ForeColor = Color.Black;
                    TextBoxSendMsg.Text = "";
                }
            }
        }

        //Пользователь отпускает клавишу в текстбоксе для отправки сообщений
        private void TextBoxSendMsg_KeyUp(object sender, KeyEventArgs e)
        {
            //Если текстбокс находится в "рабочем состоянии" и пользователь стёр последний символ в textBox
            if ((tbxMsgMode == 2) && (TextBoxSendMsg.Text == ""))
            {
                //textBox переходит в "начальное состояние" [появляется надпись "Напишите сообщение..." и текстбокс блокируется]
                tbxMsgMode = 1;
                TextBoxSendMsg.ReadOnly = true;
                TextBoxSendMsg.ForeColor = Color.LightGray;
                TextBoxSendMsg.Text = "Напишите сообщение...";
            }
        }

        //Указатель входит в область кнопки "Стереть всё"
        private void buttonClearAll_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.Teal;
            labelTitle.ForeColor = Color.Teal;
            labelRef.Text = S_ClearAll;
        }

        //Указатель выходит из области кнопки "Стереть всё"
        private void buttonClearAll_MouseLeave(object sender, EventArgs e)
        {
            LabelsTxtClr_Default();
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            string txt_msgbx = "Чат-бот" + "\r\n" +
            "Версия 2.0" + "\r\n" +
            "Добавлено 13 новых команд" + "\r\n" +
            "Ответы на старые вопросы расширены" + "\r\n" +
            "ZabGU|IVT18 Foundation" + "\r\n" +
            "2020" + "\r\n" +
            "---------------------------------------------------------------------" + "\r\n" +
            "На этой форме нужно ввести ваш вопрос в нижнее поле и нажать '>' или ENTER" + "\r\n" +
            "Если вы не знаете, что ввести, то введите 'помощь'" + "\r\n" +
            "Эта команда выведет список всех доступных команд";
            string ttl_msgbx = "Чат-бот 2.0";
            var ok_msgbx = MessageBox.Show(txt_msgbx, ttl_msgbx, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //Нажали на кнопку "Очистить всё"
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Уверены,что хотите очистить диалог?", 
                "Подтверждение", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                File.WriteAllText(bot.Path, string.Empty);
                bot.History.Clear();
                String[] date = new String[] {"Переписка от " + DateTime.Now.ToString("dd.MM.yy"+ "\n")};
                bot.AddToHistory(date);
                TextBoxChat.Text = date[0];
            }
        }

        //Указатель входит в область кнопки "Отправить сообщение"
        private void buttonSendMsg_MouseEnter(object sender, EventArgs e)
        {
            labelRef.ForeColor = Color.DarkCyan;
            labelTitle.ForeColor = Color.DarkCyan;
            labelRef.Text = S_SendMsg;
        }

        //Указатель выходит из области кнопки "Отправить сообщение"
        private void buttonSendMsg_MouseLeave(object sender, EventArgs e)
        {
            LabelsTxtClr_Default();
        }

        //Нажали на кнопку "Отправить сообщение"
        private void buttonSendMsg_Click(object sender, EventArgs e)
        {
            if (tbxMsgMode==1)
            {
                //Если текстбокс в "не рабочем режиме" то ничего не делать
                //Иначе делать
            }
            else
            {
                String[] userQuestion = TextBoxSendMsg.Text.Split(new String[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries);

                string message = userQuestion[0]; // для отправки боту

                userQuestion[0] = userQuestion[0].Insert(0,
                    "[" + DateTime.Now.ToString("HH:mm") + "] " + bot.UserName + ": ");

                bot.AddToHistory(userQuestion);

                TextBoxChat.AppendText(userQuestion[0] + "\r\n");
                TextBoxSendMsg.Text = "";
                string[] botAnswer = new string[] { bot.Answer(message) };
                botAnswer[0] = botAnswer[0].Insert(0, "Бот: ");
                TextBoxChat.AppendText(botAnswer[0] + Environment.NewLine);

                bot.AddToHistory(botAnswer);
            }
        }

        //метод восстановления чата
        public void RestoreChat()  
        {
            for (int i = 0; i < bot.History.Count; i++)
            {
                TextBoxChat.Text += bot.History[i] + Environment.NewLine;
            }
        }
    }
}