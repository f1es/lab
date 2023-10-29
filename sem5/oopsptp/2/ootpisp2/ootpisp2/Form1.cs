namespace ootpisp2
{
    public partial class Form1 : Form
    {
        static int currentId = -1;

        Catalog catalog = new Catalog();
        public Form1()
        {
            InitializeComponent();
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            ShowAddInput();
        }
        private void AcceptInputButtonClick(object sender, EventArgs e)
        {
            if (AddFilm())
                HideInput();
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            HideInput();

            if (catalog.Films.Count == 0)
            {
                OutputLabel.Visible = true;
                OutputLabel.Text = "Каталог пуст";
                return;
            }
            if (currentId == -1)
            {
                OutputLabel.Visible = true;
                OutputLabel.Text = "Фильм не выбран";
                return;
            }

            GetFilm(Form1.currentId);
            ShowEditInput();
        }
        private void AcceptIdButtonClick(object sender, EventArgs e)
        {
            int.TryParse(InputName.Text, out int id);
            Form1.currentId = id;
            HideInput();
            if (Static.InRange(0, catalog.Films.Count - 1, Form1.currentId))
            {
                CurrentIdLabel.Text = Form1.currentId.ToString();
            }
            else
            {
                OutputLabel.Visible = true;
                OutputLabel.Text = "index out of range";
                return;
            }
        }

        private void SeeFilmsButtonClick(object sender, EventArgs e)
        {
            OutputBox.Text = catalog.SeeAllFilms();
        }
        private void SelectFilmButtonClick(object sender, EventArgs e)
        {
            HideInput();
            ShowIdInput();
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (catalog.Films.Count == 0)
            {
                OutputLabel.Visible = true;
                OutputLabel.Text = "Каталог пуст";
                return;
            }
            if (currentId == -1)
            {
                OutputLabel.Visible = true;
                OutputLabel.Text = "Фильм не выбран";
                return;
            }

            catalog.DeleteFilm(currentId);
        }
        private void AcceptEditButtonClick(object sender, EventArgs e)
        {
            EditFilm(catalog.Films[currentId]);
            HideInput();
        }
        public void HideInput()
        {
            InputName.Visible = false;
            InputRating.Visible = false;
            InputType.Visible = false;
            InputYear.Visible = false;
            InputCountry.Visible = false;
            Label.Visible = false;
            Label.Text = string.Empty;
            AcceptInputButton.Visible = false;
            OutputLabel.Visible = false;
            AcceptIdButton.Visible = false;
            AcceptEditButton.Visible = false;

            InputName.Text = string.Empty;
            InputRating.Text = string.Empty;
            InputType.Text = string.Empty;
            InputYear.Text = string.Empty;
            InputCountry.Text = string.Empty;
            OutputLabel.Text = string.Empty;
        }

        public void ShowAddInput()
        {
            InputName.Visible = true;
            InputRating.Visible = true;
            InputType.Visible = true;
            InputYear.Visible = true;
            InputCountry.Visible = true;
            Label.Text = "Название\r\n\r\nГод\r\n\r\nСтрана\r\n\r\nРейтинг\r\n\r\nЖанр\r\n";
            Label.Visible = true;
            AcceptInputButton.Visible = true;
            OutputLabel.Visible = true;

            InputName.Text = "HAG";
            InputRating.Text = "100";
            InputType.Text = "sto";
            InputYear.Text = "2022";
            InputCountry.Text = "Belarus";
            //OutputLabel.Text = string.Empty;
        }

        public void ShowIdInput()
        {
            AcceptIdButton.Visible = true;
            InputName.Visible = true;
            Label.Visible = true;
            Label.Text = "id фильма";
        }

        public void ShowEditInput()
        {
            InputName.Visible = true;
            InputRating.Visible = true;
            InputType.Visible = true;
            InputYear.Visible = true;
            InputCountry.Visible = true;
            Label.Text = "Название\r\n\r\nГод\r\n\r\nСтрана\r\n\r\nРейтинг\r\n\r\nЖанр\r\n";
            Label.Visible = true;
            AcceptEditButton.Visible = true;
            OutputLabel.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HideInput();
        }

        public bool AddFilm()
        {
            Film film = new Film();

            if (!film.AddName(InputName.Text))
            {
                OutputLabel.Text = "Некоректное имя";
                return false;
            }

            if (!film.AddYear(InputYear.Text))
            {
                OutputLabel.Text = "Некоректный год";
                return false;
            }

            if (!film.AddCountry(InputCountry.Text))
            {
                OutputLabel.Text = "Некоректная страна";
                return false;
            }

            if (!film.AddRating(InputRating.Text))
            {
                OutputLabel.Text = "Некоректный рейтинг";
                return false;
            }

            if (!film.AddType(InputType.Text))
            {
                OutputLabel.Text = "Некоректный жанр";
                return false;
            }

            catalog.AddFilm(film);
            return true;
        }

        public bool EditFilm(Film film)
        {
            //Film film = new Film();

            if (!film.AddName(InputName.Text))
            {
                OutputLabel.Text = "Некоректное имя";
                return false;
            }

            if (!film.AddYear(InputYear.Text))
            {
                OutputLabel.Text = "Некоректный год";
                return false;
            }

            if (!film.AddCountry(InputCountry.Text))
            {
                OutputLabel.Text = "Некоректная страна";
                return false;
            }

            if (!film.AddRating(InputRating.Text))
            {
                OutputLabel.Text = "Некоректный рейтинг";
                return false;
            }

            if (!film.AddType(InputType.Text))
            {
                OutputLabel.Text = "Некоректный жанр";
                return false;
            }

            catalog.Films[Form1.currentId] = film;
            return true;
        }

        public void GetFilm(int id)
        {
            InputName.Text = catalog.Films[id].Name;
            InputRating.Text = catalog.Films[id].Rating.ToString();
            InputType.Text = catalog.Films[id].Type;
            InputYear.Text = catalog.Films[id].Year.ToString();
            InputCountry.Text = catalog.Films[id].Country;
        }


    }
}