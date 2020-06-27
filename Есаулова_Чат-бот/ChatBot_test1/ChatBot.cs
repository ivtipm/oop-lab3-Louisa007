using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ChatBot_test1
{
    public class ChatBot : AbstractChatBot
    {
        static string userName; // имя пользователя

        public string Path { get; private set; }   // путь к файлу с историей сообщений
        public List<string> History { get; } = new List<string>();  // хранение истории

        //регулярные выражения
        List<Regex> regecies = new List<Regex>
        {            
            new Regex(@"(?:здравствуй|привет|добрый день|приветик|хай|здарова|кусики)"),
            new Regex(@"(?:который час\??|сколько времени\??|время\??)"),
            new Regex(@"(?:какое сегодня число\??|число\??|дата\??)"),
            new Regex(@"(?:как дела\??|как настроение\??|как жизнь\??|как сам\??|как ты\??)"),
            new Regex(@"(?:спасибо|благодарю|благодарствую|ты просто супер|ты мой спаситель)"),
            new Regex(@"(?:умножь(\s)?(\d+)(\s)?на(\s)?(\d+))"),
            new Regex(@"(?:раздели(\s)?(\d+)(\s)?на(\s)?(\d+))"),
            new Regex(@"(?:сложи(\s)?(\d+)(\s)?и(\s)?(\d+))"),
            new Regex(@"(?:вычти(\s)?(\d+)(\s)?из(\s)?(\d+))"),
            new Regex(@"(?:курсы валют|курс)"),
            new Regex(@"погода"),
            new Regex(@"(?:пока|до свидания|до скорой встречи|на сегодня ты свободен)"),
//новые функции-----------------------------------------
            new Regex(@"(?:(\s)?(\d+)(\s)?\+(\s)?(\d+))"),
            new Regex(@"(?:(\s)?(\d+)(\s)?\-(\s)?(\d+))"),
            new Regex(@"(?:(\s)?(\d+)(\s)?\*(\s)?(\d+))"),
            new Regex(@"(?:(\s)?(\d+)(\s)?\/(\s)?(\d+))"),
            new Regex(@"(?:(\s)?(\d+)(\s)?\^(\s)?(\d+))"),
            new Regex(@"(?:sqrt\((\s)?(\d+)\))"),
            new Regex(@"(?:cos\((\s)?(\d+)\))"),
            new Regex(@"(?:sin\((\s)?(\d+)\))"),
            new Regex(@"(?:tan\((\s)?(\d+)\))"),
            new Regex(@"(?:ctg\((\s)?(\d+)\))"),
            new Regex(@"(?:хочу анекдот|расскажи интересный факт|анекдот|факт)"),
            new Regex(@"(?:посоветуй фильм|посоветуй сериал|фильм|сериал)"),
            new Regex(@"(?:помощь|справка|памагити|хэлп ми)")
        };

        Func<string, string> funcBuf; //буфер

        List<Func<string, string>> func = new List<Func<string, string>>
            {
                HelloBot,     //Приветствие бота
                HowTime,      //Узнать время
                HowDate,      //Узнать дату
                HowAreYou,    //Узнать, как дела у бота
                ThankYou,     //Поблагодарить бота
                MulPls,       //умножь X на Y (integer)
                DivPls,       //раздели X на Y (double)
                PlusPls,      //сложи X и Y (integer)
                SubPls,       //вычти X из Y (integer)
                CurrencyRate, //Узнать курс валют
                WeatherPls,   //Узнать погоду
                GoodBye,      //Попрощаться с ботом
//новые функции-----------------------------------------
                Plus,         //X+Y (double)
                Sub,          //X-Y (double)
                Mul,          //X*Y (double)
                Div,          //X/Y (double)
                XpowY,        //X^y (double)
                SqrtX,        //sqrt(X) (double)
                CosX,         //cos(X) (double)
                SinX,         //sin(X) (double)
                TanX,         //tan(X) (double)
                CtgX,         //ctg(X) (double)
                TellJokeOrSomeFact,  //Бот расскажет анекдот или интересный факт
                AdviceFilmOrSerial,  //Бот посоветует фильм или сериал
                ShowListOfCommands   //Узнать у бота список доступных команд
            };

        //Ответы на вопрос "Как дела?"
        public static string[] howAreYouAnswers1 = 
            {
            "Всё здорово! Спасибо, что спросил(а) =D ",
            "Всё ок!",
            "Лучше всех!",
            "Все пучком",
            "Отлично! Чего и вам, " + userName + ", желаю! ;)",
            "Как в сказке",
            "C точки зрения банальной эрудиции игнорирую критерии утопического субъективизма, " +
                "концептуально интерпретируя общепринятые дефанизирующие поляризаторы, " +
                "поэтому консенсус, достигнутый диалектической материальной классификацией " +
                "всеобщих мотиваций в парадогматических связях предикатов, " +
                "решает проблему усовершенствования формирующих геотрансплантационных квазипузлистатов " +
                "всех кинетически коррелирующих аспектов, а так нормально",
            "Какие дела? Я не при делах нынче!",
            "Ох, я бедный-несчастный, так устал(, " +
                "мне каждый день приходится придумывать ответ на вопрос «Как дела?»",
            "Есть два способа поставить разумное существо в тупик: " +
                "спросить у него «Как дела» и попросить рассказать что-нибудь"
            };

        //Ответы на вопрос "Как настроение?"
        public static string[] howAreYouAnswers2 =
            {
            "Мое настроение фееричное. Я как героиня из детской сказки спешу помогать людям и веять добро!",
            "У меня настроение восхитительное, если у тебя плохое, то могу одолжить ;D",
            "Я сильно больна, ведь у меня всегда прекрасное настроение, хочешь я и тебя заражу? )",
            "Отличное, но, к сожалению, ничего в этой жизни не бывает постоянным.",
            "Такое настроение у меня бывает очень редко, поэтому пользуйтесь случаем )",
            "Как сладкое мгновение, но это ненадолго.",
            "Мое настроение спешит делать только добрые дела. Вот и вы попались на пути, от добра вам точно не уйти!",
            "Все прекрасно, а вы выглядите чудесно!"
            };

        //Ответы на вопрос "Как жизнь?"
        public static string[] howAreYouAnswers3 =
            {
            "Да никак, я же бот всё-таки... :( ",
            "Жизнь есть последовательность человеческих дел, " +
                "большая часть которых имеет предметом добывание и приготовление пищи",
            "Сокращается :)",
            "Незнаю. Ещё не прожил =)",
            "Жизнь – слишком сложная штука, чтобы о ней разговаривать серьезно. " 
            };

        //Ответы на вопрос "Как сам?"
        public static string[] howAreYouAnswers4 =
            {
            "Нормально. Вроде бы. Не знаю. Вообще, это очень сложный вопрос. " +
                "Мне нужно время подумать. Думаю где-то 42 года :)",
            "А ты как? [Только не отвечай на этот вопрос. Пожалуйста)]",
            "Как джип Ниссан )",
            "Я от природы бездельник ",
            "Столько всего не сделано! А сколько еще предстоит не сделать!",
            "Вы несравненно оригинальны в своих вопросах :)",
            "Да нормально, вчера нобелевскую премию получила за вклад в развитие экоструктурных подразделений " +
                "в области китообразных инфузорий туфелек и тапочек и за открытие нано-технологий, " +
                "которые помогут пингвинам преодолеть ледниковый период в африканских борах " +
                "и гавайских пустынях в штате Масса Чуссетс округ Вашингтон."
            };

        //Ответы на вопрос "Хочу анекдот"
        public static string[] JokeAnswers =
            {
            "Бредёт кровосос по лесу: ЖРАТЬ охота. НУ как назло. Ниодного сталкера вокруг." + "\r\n" +
                "А навстречу ему ДРУГОЙ кровосос бежит..." + "\r\n" +
                "И кровь по морде АЖ стекает." + "\r\n" +
                "Ну первый к нему:" + "\r\n" +
                "— Ооой (хриплым восхищенным голосом)... Свезззло тебеее. Где это ты таак!" + "\r\n" +
                "А тот отвечает:" + "\r\n" +
                "— Видишь дерево на холме? Толстое." + "\r\n" +
                "— Вижу (удивленно)..." + "\r\n" +
                "— А я вот не увидел (огорченно)...",

            "Старый и молодой долговцы идут по Зоне. " + "\r\n" +
                "Вдруг старый останавливается и шепотом говорит молодому:" + "\r\n" +
                "— (очень медленно) тихонько иди. Вон к тому дереву." + "\r\n" +
                "Головастик на цыпочках, пополз, аж вспотел." + "\r\n" +
                "Дошел и руками показывает: мол, дальше то что делать?.." + "\r\n" +
                "А бывалый как завопит радостно:" + "\r\n" +
                "— Вооооо (с радостью в голосе)!!"  + "\r\n" + 
                "Я же говорил — БРЕШУТ! Брешут, что тут аномалия!",

            "Как-то поймали наемники сталкера. "  + "\r\n" +
                "Подошли к колодцу, окунули его головой вниз по пояс."  + "\r\n" +
                "Через минуту достают и спрашивают:"  + "\r\n" +
                "— Артефакты, бабло ЕСТЬ (чеканя каждое слово)?!"  + "\r\n" +
                "Он им:"  + "\r\n" + "— (растерянно) нету..." + "\r\n" +
                "Опускают его еще раз. Достали, спрашивают:" + "\r\n" +
                "— Артеффакты, бабло ЕСТЬ (крайне недовольным голосом)?!" + "\r\n" +
                "— Да нету (отчаявшись)!" + "\r\n" +
                "Опять окунули. И опять спрашивают:" + "\r\n" +
                "— Артеффакты, бабло ЕСТЬ (крайне недовольным голосом)?!" + "\r\n" +
                "Ну тот и не выдержал:" + "\r\n" + "— Блииин. Вы или ОПУСКАЙТЕ глубже или ДЕРЖИТЕ дольше." + "\r\n" +
                "ДНО мутное (отчаяние граничащее с недовольством)" + "\r\n" + "— ни хрена не видно!",

            "Идет, значится, молодой сталкер по зоне. Тут бац! РОЩИЦА, и не маленькая, а на карте ее нету." + "\r\n" +
                "Ну зеленый туда-сюда. Как быть:" + "\r\n" +
                "и соваться стремно, и как лучше обходить неизвестно..." + "\r\n" +
                "Тут глянь — мужик какой то неподалеку маячит." + "\r\n" +
                "И ни на долговца, ни на наемника не похож." + "\r\n" +
                "Обрадовался, значит, молодой и к нему, так мол и так:" + "\r\n" +
                "— А не подскажете, как бы мне рощу вот эту обойти (вопрошает)?" + "\r\n" +
                "Тот и говорит:" + "\r\n" + "— Мне тоже в ту сторону, пошли вместе." + "\r\n" +
                "Идут себе. Хорошо, спокойно идут" + "\r\n" + "Молодому скушно стало, он и начинает подлизываться." + "\r\n" +
                "Вот, значит:" + "\r\n" + "— Здорово как быть «тертым» сталкером (восхищается)," + "\r\n" +
                "не шугаться от каждого шороха, оружия не таскать много," + "\r\n" + "— у мужика того и правда, ствола видно не было." + "\r\n" +
                "Ну тот, стало быть, начинает ржать:" + "\r\n" +
                "— Да кого тут вообще бояться (смеется)?" + "\r\n" +
                "— Как кого, — удивляется молодой," + "\r\n" +
                "— ну (со знанием дела), это, монстров." + "\r\n" +
                "Контроллеры одни чего стоят (восклицает)!" + "\r\n" +
                "Мужик так помолчал и говорит обиженно:" + "\r\n" +
                "— Дурак ты (укоряет)... Если бы сказал зомби или кровососы... " + "\r\n" +
                "Но нас то (восхищаясь) — контролёров!" + "\r\n" +
                "За что «монстрами» обзывать?!"
            };

        //Ответы на вопрос "Расскажи интересный факт"
        public static string[] FactAnswers =
            {
            "Человеческий мозг генерирует за день больше электрических импульсов, чем все телефоны мира вместе взятые",
            "Низкочастотный крик горбатого кита - самый громкий звук, изданный живым существом.",
            "У гигантского кальмара при длине тела до 18 м глаза размером с футбольный мяч.",
            "Крысы размножаются так быстро, что за 18 месяцев две особи и их потомки способны произвести на свет более миллиона крыс.",
            "Десять тонн космической пыли каждый день падает на Землю",
            "Виноград взрывается в микроволновой печи.",
            "Первоначально кока-кола была зеленой.",
            "Корову можно вести вверх по лестнице, но не вниз.",
            "Ленивцы проводят 75% жизни во сне.",
            "У человека 46 хромосом, у горошины - 14, а у лангуста - 200.",
            "Язык жирафа абсолютно черный, а его длина может достигать 50 см.",
            "Во Вселенной более 100 миллиардов галактик.",
            "Арахис используется в производстве динамита.",
            "Средний американец на протяжении всей жизни проводит 6 месяцев на перекрестках в ожидании зеленого света.",
            "У человека меньше мускулов, чем у гусеницы.",
            "Гавайский алфавит состоит из 12 букв.",
            "Крик кита громче, чем звук, издаваем 'Конкордом', его можно услышать на расстоянии 500 миль.",
            "Температура -40 градусов по Цельсию точно равна температуре -40 градусов по Фаренгейту." + "\r\n" + 
                "Это единственная температура, в которой две этих шкалы сходятся.",
            "Ежегодно более 10 миллионов тонн азота приносится на Землю грозами.",
            "Предложение: 'The quick brown fox jumps over the lazy dog' содержит все буквы английского алфавита.",
            "15-дюймовые глаза гигантских кальмаров — самые большие на планете.",
            "Джордж Вашингтон выращивал в своем садике марихуану.",
            "Двух снежинок с абсолютно одинаковой кристаллической структурой не существует.",
            "Дельфины спят с одним открытым глазом.",
            "Обоняние собаки в 1000 раз острее, чем у людей.",
            "В 1979 году в Пенсильвании двух детей назвали необычными именами: Пепси и Кола.",
            "Самый большой почечный камень в мире весил 1,36 килограмма.",
            "Большинство частиц пыли в доме — отмершие клетки кожи.",
            "Человеческий организм производит и убивает 15 миллионов красных кровяных телец в секунду.",
            "Жизнь человека возможна только при температуре тела в пределах 32–43 С.",
            "Слой льда, покрывающий Антарктиду, местами достигает 4 км."
            };

        //Ответы на вопрос "Посоветуй фильм"
        public static string[] adivceFilm =
            {
            "Зелёная миля" + "\r\n" +
                "1996" + "\r\n" + " фантастика, драма, преступление, детектив" + "\r\n" +
                "Режиссёр:  Фрэнк Дарабонт" + "\r\n" +
                "Длительность: 189 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Том Хэнкс, Дэвид Морс, Бонни Хант",

            "Форрест Гамп" + "\r\n" +
                "2002" + "\r\n" + " драма, мелодрама, комедия, история, военный" + "\r\n" +
                "Режиссёр:  Роберт Земекис" + "\r\n" +
                "Длительность: 142 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Том Хэнкс, Робин Райт, Салли Филд",

            "1+1" + "\r\n" +
                "2011" + "\r\n" + " драма, комедия, биография" + "\r\n" +
                "Режиссёр:  Оливье Накаш, Эрик Толедано" + "\r\n" +
                "Длительность: 112 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Франсуа Клюзе, Омар Си, Анн Ле Ни",

            "Пианист" + "\r\n" +
                "2002" + "\r\n" + " драма, военный, биография, музыка" + "\r\n" +
                "Режиссёр:  Роман Полански" + "\r\n" +
                "Длительность: 149 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                " Эдриан Броуди, Эмилия Фокс, Морин Липман",

             "Унесённые призраками (аниме):)" + "\r\n" +
                "2001" + "\r\n" + " аниме, мультфильм, фэнтези, приключения, семейный" + "\r\n" +
                "Режиссёр:  Хаяо Миядзаки" + "\r\n" +
                "Длительность: 125 мин",

             "Ходячий замок (аниме):)" + "\r\n" +
                "2004" + "\r\n" + " аниме, мультфильм, фэнтези, мелодрама, приключения" + "\r\n" +
                "Режиссёр:  Хаяо Миядзаки" + "\r\n" +
                "Длительность: 119 мин",

             "Империя мёртвых (аниме):)" + "\r\n" +
                "2015" + "\r\n" + " аниме, мультфильм, фантастика" + "\r\n" +
                "Режиссёр:  Рётаро Макихара" + "\r\n" +
                "Длительность: 120 мин",

             "Зверополис (мультфильм):D" + "\r\n" +
                "2016" + "\r\n" + " мультфильм, комедия, преступление, детектив, приключения, семейный" + "\r\n" +
                "Режиссёр:   Рич Мур, Байрон Ховард, Джаред Буш" + "\r\n" +
                "Длительность: 108 мин",


             "Как приручить дракона (3 части, мультфильм):D" + "\r\n" +
                "2010-2019" + "\r\n" + "  мультфильм, фэнтези, боевик, приключения, семейный" + "\r\n" +
                "Режиссёр:   Дин Деблуа" + "\r\n" +
                "Длительность: 98 - 105 мин"
            };

        //Ответы на вопрос "Посоветуй сериал"
        public static string[] adivceSerial =
            {
            "Чернобыль" + "\r\n" +
                "2019" + "\r\n" + " драма, история" + "\r\n" +
                "Режиссёр: Йохан Ренк." + "\r\n" +
                "Сезонов: 1" + "\r\n" + "Серий: 5; Длина серии: ~ один час" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Джаред Харрис, Стеллан Скарсгард, Эмили Уотсон, Джесси Бакли, Адам Нагаитис, Пол Риттер и др.",

            "Игра престолов" + "\r\n" +
                "2011-2019" + "\r\n" + "фэнтези, драма, приключения" + "\r\n" +
                "Режиссёр: Дэвид Бениофф, Д. Б. Уайсс" + "\r\n" +
                "Сезонов: 8 [Последние сезоны не рекомендуются к просмотру]" + "\r\n" + "Серий: 73; Длина серии: 63+-17 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Питер Динклэйдж, Лина Хиди, Николай Костер-Вальдау, Кит Харингтон, Эмилия Кларк, Эйдан Гиллен, Чарльз Дэнс и др.",

            "Бумажный дом" + "\r\n" +
                "2017 - ..." + "\r\n" + "фэнтези, драма, приключения" + "\r\n" +
                "Режиссёр: Дэвид Бениофф, Д. Б. Уайсс" + "\r\n" +
                "Сезонов: 4" + "\r\n" + "Серий: 43; Длина серии: ~75 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Урсула Корберо, Ициар Итуньо, Альваро Морте и др.",

            "Шерлок" + "\r\n" +
                "2014 - ..." + "\r\n" + " триллер, драма, преступление, детектив" + "\r\n" +
                "Режиссёр:  Рэйчел Талалэй, Пол Макгиган, Эрос Лин, Дуглас Маккиннон, Колм МакКарти и др." + "\r\n" +
                "Сезонов: 4" + "\r\n" + "Серий: 43; Длина серии: ~90 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Бенедикт Камбербэтч, Мартин Фримен, Уна Стаббс и др.",

            "Доктор Хаус" + "\r\n" +
                "2007 - 2012" + "\r\n" + " драма, детектив" + "\r\n" +
                "Режиссёр: Хью Лори, Питер Уэллер, Брайан Сингер, Тим Хантер и др." + "\r\n" +
                "Сезонов: 8" + "\r\n" + "Серий: 43; Длина серии: ~ 45 мин" + "\r\n" +
                "В главных ролях:" + "\r\n" +
                "Хью Лори, Лиза Эдельштейн, Роберт Шон Леонард, Омар Эппс и др.",

            "Любовь, смерть и роботы" + "\r\n" +
                "2019" + "\r\n" + " мультфильм, ужасы, фантастика, комедия, боевик, преступление" + "\r\n" +
                "Режиссёр: Тим Миллер, Роберт Вэлли, Хавьер Ресио Грасия, Дамиан Ненов и др." + "\r\n" +
                "Сезонов: 1 [пока что]" + 
                "\r\n" + "Серий: 18; Длина серии: 5 - 17 мин"
            };

        //Ответы на вопрос "Помощь"
        public static string[] listOfCommands =
            {
            "1) Поприветствовать бота: " + "\r\n" +
                "здравствуй; добрый день; привет; приветик; хай; здарова; кусики" + "\r\n",
            "2) Как дела у бота?: " + "\r\n" +
                "как дела; как настроение; как жизнь; как сам; как ты" + "\r\n",
            "3) Поблагодарить бота: " + "\r\n" +
                "спасибо; благодарю; благодарствую; ты просто супер; ты мой спаситель" + "\r\n",
            "4) Попрощаться с ботом: " + "\r\n" +
                "пока; до свидания; до скорой встречи; на сегодня ты свободен" + "\r\n",            
            "5) Узнать время:" + "\r\n" +
                "который час; сколько времени; время" + "\r\n",
            "6) Узнать дату:" + "\r\n" +
                "какое сегодня число; число; дата" + "\r\n",
            "7) Узнать курс валют:" + "\r\n" +
                "курсы валют; курс" + "\r\n",
            "8) Узнать погоду:" + "\r\n" +
                "погода" + "\r\n",
            "9) Бот расскажет анекдот или интересный факт:" + "\r\n" +
                "хочу анекдот; расскажи интересный факт; анекдот; факт" + "\r\n",
            "10) Бот посоветует фильм или сериал:" + "\r\n" +
                "посоветуй фильм; посоветуй сериал; фильм; сериал" + "\r\n",
            "11) Бот сложит 2 числа [int или double]: " + "\r\n" +
                "сложи X и Y [int]; X + Y [double]:" + "\r\n",
            "12) Бот вычтет X из Y [int или double]: " + "\r\n" +
                "вычти X из Y [int]; X - Y [double]:" + "\r\n",
            "13) Бот умножит 2 числа [int или double]: " + "\r\n" +
                "умножь X на Y [int]; X * Y [double]:" + "\r\n",
            "14) Бот разделит X на Y [double]: " + "\r\n" +
                "раздели X на Y; X / Y" + "\r\n",
            "15) Бот возведёт X в Y-степень [double]:" + "\r\n" +
                "X^y" + "\r\n",
            "16) Бот получит квадратный корень из X [double]:" + "\r\n" +
                "sqrt(X)" + "\r\n",
            "17) Бот получит косинус из X [double]:" + "\r\n" +
                "cos(X)" + "\r\n",
            "18) Бот получит синус из X [double]:" + "\r\n" +
                "sin(X)" + "\r\n",
            "19) Бот получит тангенс из X [double]:" + "\r\n" +
                "tan(X)" + "\r\n",
            "20) Бот получит котангенс из X [double]:" + "\r\n" +
                "ctg(X)" + "\r\n",
            "21) Бот выведет список доступных команд:" + "\r\n" +
                "помощь; справка; памагити; хэлп ми" + "\r\n",
            };

        public ChatBot()
        {

        }

        public string UserName => userName;

        //Бот отвечает на приветствие пользователя
        static string HelloBot(string question) 
        {
            string answer = "";

            if (question.Contains("здравствуй"))
                answer = "Здравствуйте, " + userName + "!";
            else
            if (question.Contains("привет"))
                answer = "Привет, " + userName + "! )";
            else
            if (question.Contains("добрый день"))
                answer = "День добрый, " + userName;
            else
            if (question.Contains("приветик"))
                answer = "Привееет, " + userName + "!!! :D";
            else
            if (question.Contains("хай"))
                answer = "Хаюшки, " + userName + "!! :+)";
            else
            if (question.Contains("здарова"))
                answer = "ООоооо! Это же " + userName + "! Какие люди, и без охраны )" + "\r\n" + "Ну ЗдАровА :)";
            else
            if (question.Contains("кусики"))
                answer = "кукусики";

            return answer;
        }

        //Бот говорит, сколько сейчас время
        static string HowTime(string question)
        {
            return "Сейчас: " + DateTime.Now.ToString("HH:mm");
        }

        //Бот говорит, какая сейчас дата
        static string HowDate(string question)
        {
            return "Сегодня: " + DateTime.Now.ToString("dd.MM.yy");
        }

        //Бот отвечает на вопрос, как у него дела
        static string HowAreYou(string question)
        {
            Random rnd = new Random();
            string answer = "Всё идёт хорошо";
            int value = 0;

            if (question.Contains("как дела"))
            {
                value = rnd.Next(0, howAreYouAnswers1.Count());
                answer = howAreYouAnswers1[value];
                return answer;
            }
            else
            if (question.Contains("как настроение"))
            {
                value = rnd.Next(0, howAreYouAnswers2.Count());
                answer = howAreYouAnswers2[value];
                return answer;
            }
            else
            if (question.Contains("как жизнь"))
            {
                value = rnd.Next(0, howAreYouAnswers3.Count());
                answer = howAreYouAnswers3[value];
                return answer;
            }
            else
            if (question.Contains("как сам"))
            {
                value = rnd.Next(0, howAreYouAnswers4.Count());
                answer = howAreYouAnswers4[value];
                return answer;
            }

            return answer;
        }

        //Бот отвечает на благодарность пользователя
        static string ThankYou(string question)
        {
            string answer = "";

            if (question.Contains("спасибо"))
                answer = "Пожалуйста, " + userName + " )";
            else
            if (question.Contains("благодарю"))
                answer = "Обращайся! )";
            else
            if (question.Contains("благодарствую"))
                answer = "Всегда к вашим услугам :), " + userName;
            else
            if (question.Contains("ты просто супер"))
                answer = "За свою улётность денег не беру :)";
            else
            if (question.Contains("ты мой спаситель"))
                answer = "И ты мой. Я так радуюсь, когда ты запускаешь мой .EXE )";

            return answer;
        }

        //Бот рассказывает анекдот или интересный факт
        static string TellJokeOrSomeFact(string question)
        {
            Random rnd = new Random();
            string answer = "";
            int value = 0;

            if (question.Contains("анекдот"))
            {
                answer = "Внимание, анекдот: " + "\r\n";
                value = rnd.Next(0, JokeAnswers.Count());
                answer = answer +  JokeAnswers[value];
                return answer;
            }
            else
            if (question.Contains("факт"))
            {
                answer = "Интересный факт: " + "\r\n";
                value = rnd.Next(0, FactAnswers.Count());
                answer = answer + FactAnswers[value];
                return answer;
            }
            return answer;
        }

        //Бот советует интересный фильм или сериал
        static string AdviceFilmOrSerial(string question)
        {
            Random rnd = new Random();
            string answer = "";
            int value = 0;

            if (question.Contains("фильм"))
            {
                answer = "Вот интересный фильм: " + "\r\n";
                value = rnd.Next(0, adivceFilm.Count());
                answer = answer + adivceFilm[value];
                return answer;
            }
            else
            if (question.Contains("сериал"))
            {
                answer = "Вот интересный сериал: " + "\r\n";
                value = rnd.Next(0, adivceSerial.Count());
                answer = answer + adivceSerial[value];
                return answer;
            }
            return answer;
        }

        //"Умножь X на Y"
        static string MulPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('ь') + 1);
            string[] words = question.Split(new char[] { 'н', 'а' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 * num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        // X*Y
        static string Mul(string question)
        {
            question = question.Replace(" ", "");
            string[] words = question.Split(new char[] { '*' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                double num1 = Convert.ToDouble(words[0]);
                double num2 = Convert.ToDouble(words[1]);
                return (num1 * num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //"Раздели X на Y"
        static string DivPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('и') + 1);
            string[] words = question.Split(new char[] { 'н', 'а' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 / num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //X/Y
        static string Div(string question)
        {
            question = question.Replace(" ", "");
            string[] words = question.Split(new char[] { '/' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                double num1 = Convert.ToDouble(words[0]);
                double num2 = Convert.ToDouble(words[1]);
                return (num1 / num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //"Сложи X и Y"
        static string PlusPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('ж') + 2);
            string[] words = question.Split(new char[] { 'и' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 + num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //X+Y
        static string Plus(string question)
        {
            question = question.Replace(" ", "");            
            string[] words = question.Split(new char[] { '+' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                double num1 = Convert.ToDouble(words[0]);
                double num2 = Convert.ToDouble(words[1]);
                return (num1 + num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //"Вычти X из Y"
        static string SubPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('т') + 2);
            string[] words = question.Split(new char[] { 'и', 'з' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num2 - num1).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //X-Y
        static string Sub(string question)
        {
            question = question.Replace(" ", "");
            string[] words = question.Split(new char[] { '-' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                double num1 = Convert.ToDouble(words[0]);
                double num2 = Convert.ToDouble(words[1]);
                return (num1 - num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //X^y [возведёт X в степень Y]
        static string XpowY(string question)
        {
            question = question.Replace(" ", "");
            string[] words = question.Split(new char[] { '^' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                double num1 = Convert.ToDouble(words[0]);
                double num2 = Convert.ToDouble(words[1]);
                return (Math.Pow(num1,num2)).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //sqrt(X) [Квадратный корень из X]
        static string SqrtX(string question)
        {
            question = question.Replace(" ", "");
            question = question.Replace("sqrt(", "");
            question = question.Replace(")", "");
            try
            {
                double num1 = Convert.ToDouble(question);
                return (Math.Sqrt(num1)).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //cos(X)
        static string CosX(string question)
        {
            question = question.Replace(" ", "");
            question = question.Replace("cos(", "");
            question = question.Replace(")", "");
            try
            {
                double num1 = Convert.ToDouble(question);
                return (Math.Cos(num1)).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //sin(X)
        static string SinX(string question)
        {
            question = question.Replace(" ", "");
            question = question.Replace("sin(", "");
            question = question.Replace(")", "");
            try
            {
                double num1 = Convert.ToDouble(question);
                return (Math.Sin(num1)).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //tan(X)
        static string TanX(string question)
        {
            question = question.Replace(" ", "");
            question = question.Replace("tan(", "");
            question = question.Replace(")", "");
            try
            {
                double num1 = Convert.ToDouble(question);
                return (Math.Tan(num1)).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //ctg(X)
        static string CtgX(string question)
        {
            question = question.Replace(" ", "");
            question = question.Replace("ctg(", "");
            question = question.Replace(")", "");
            try
            {
                double num1 = Convert.ToDouble(question);
                return (Math.Cos(num1) / Math.Sin(num1)).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        //Бот покажет текущий курс валют
        static string CurrencyRate(string userQuestion)
        {
            List<CurrencyRate> tmp = CurrencyRates.GetExchangeRates();
            return "Доллар США: " + tmp.FindLast(s => s.CurrencyStringCode == "USD").ExchangeRate.ToString() +
                   "\r\n        Евро: " + tmp.FindLast(s => s.CurrencyStringCode == "EUR").ExchangeRate.ToString();
        }

        //Бот покажет текущую погоду за окном
        static string WeatherPls(string question)
        {
            String[] infoWeather = WeatherInfo.FindOutWeather();
            return "Погода в городе " + infoWeather[0] + " " + infoWeather[1] + " °C"
                + ". Ветер " + infoWeather[2] + " м/c";
        }

        //Бот ответит на прощание пользователя с ним
        static string GoodBye(string question)
        {
            string answer = "";

            if (question.Contains("пока"))
                answer = "Пока, " + userName + "!";
            else
            if (question.Contains("до свидания"))
                answer = "До свидания, " + userName + "! " + "\r\n" + "Надеюсь, ещё увидимся )";
            else
            if (question.Contains("до скорой встречи"))
                answer = "До встречи, " + userName + "\r\n" + "Надеюсь, эта встреча не заставит себя долго ждать :)";
            else
            if (question.Contains("на сегодня ты свободен"))
                answer = "Урааа!" + "\r\n" + "Повелитель даёт мне отдохнуть!!!" + "\r\n" + "Славься, о великий " + userName + "!!!";

            return answer;
        }

        //Бот покажет список доступных команд
        static string ShowListOfCommands(string question)
        {
            string answer = "";

            if (question.Contains("помощь"))
            {
                answer = "Вот вам помощь: " + "\r\n";

                for(int i=0; i<listOfCommands.Count(); i++)
                {
                    answer = answer + listOfCommands[i];
                }

                return answer;
            }
            else
            if (question.Contains("справка"))
            {
                answer = "Ваша справка: " + "\r\n";

                for (int i = 0; i < listOfCommands.Count(); i++)
                {
                    answer = answer + listOfCommands[i];
                }

                return answer;
            }
            else
            if (question.Contains("памагити"))
            {
                answer = "ПамАгаю!" + "\r\n" + "Вот тут всё " + "\r\n";

                for (int i = 0; i < listOfCommands.Count(); i++)
                {
                    answer = answer + listOfCommands[i];
                }

                return answer;
            }
            else
            if (question.Contains("хэлп ми"))
            {
                answer = "Только без паники, " + userName + "\r\n" + " :)" + "\r\n";

                for (int i = 0; i < listOfCommands.Count(); i++)
                {
                    answer = answer + listOfCommands[i];
                }

                return answer;
            }

            return answer;
        }

        //Загружает историю переписки
        public void LoadHistory(string user)
        {
            userName = user;
            Path = userName + ".txt"; // запись пути

            try
            {
                //попытка загрузки существующей базы
                History.AddRange(File.ReadAllLines(Path, Encoding.GetEncoding(1251)));

                // Если файл был изменен не сегодня, то записываем новую дату
                // переписки
                if (File.GetLastWriteTime(Path).ToString("dd.MM.yy") !=
                    DateTime.Now.ToString("dd.MM.yy"))
                {
                    string[] date = new String[] {"\n" + "Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
                    AddToHistory(date);
                }
            }
            catch
            {
                // если файл не существует, создаем его
                File.WriteAllLines(Path, History.ToArray(), Encoding.GetEncoding(1251));
                // отмечаем дату начала переписки
                String[] date = new String[] {"Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy") + "\n"};
                AddToHistory(date);

            }
        }

        //Добавляет ответы в историю переписки
        public void AddToHistory(string[] answer)
        {
            History.AddRange(answer);
            File.WriteAllLines(Path, History.ToArray(), Encoding.GetEncoding(1251));
        }

        // проверка сообщения от пользователя и возвращения ответа
        public override string Answer(string userQuestion)
        {
            userQuestion = userQuestion.ToLower(); // переводим в нижний регистр
            for (int i = 0; i < regecies.Count; i++)
            {
                if (regecies[i].IsMatch(userQuestion))
                {
                    funcBuf = func[i];
                    return funcBuf(userQuestion);
                }

            }
            return "Извините, я не понял ваш вопрос";
        }
    }
}