namespace MVVMTestProject.ViewModel
{
    public class TeamViewModel : BaseViewModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    }
}