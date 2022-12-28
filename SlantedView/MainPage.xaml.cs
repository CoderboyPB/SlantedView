namespace SlantedView;

public partial class MainPage : ContentPage
{
	public List<string> ImageList1 { get; set; }
    public List<string> ImageList2 { get; set; }
    public List<string> ImageList3 { get; set; }
    public List<string> ImageList4 { get; set; }

    private List<string> _allImages;

    private Random _random = new();

    public MainPage()
	{
		InitializeComponent();

        GenerateData();
        ImageList1 = Randomize(_allImages);
        ImageList2 = Randomize(_allImages);
        ImageList3 = Randomize(_allImages);
        ImageList4 = Randomize(_allImages);

        BindingContext = this;

        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(0.1);
        timer.Tick += Timer_Tick;
        timer.Start();
	}

    private int direction = 1;
    private int pos = 0;

    private void Timer_Tick(object sender, EventArgs e)
    {
        if(pos <= 170)
        {
            grid1.TranslationX = direction * pos++;
            grid2.TranslationX = -direction * pos++;
            grid3.TranslationX = direction * pos++;
            grid4.TranslationX = -direction * pos++;
        }
        else
        {
            pos = 0;
            direction *= -1;
        } 
    }

    private void GenerateData()
    {
        _allImages = new();

        for(int i = 1; i <= 20; i++) 
        {
            _allImages.Add($"img{i.ToString("00")}.jpg");
        }
    }

    public List<T> Randomize<T>(List<T> source) =>
        source.OrderBy<T, int>((item) => _random.Next()).ToList();
}