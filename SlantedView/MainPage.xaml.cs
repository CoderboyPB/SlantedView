namespace SlantedView;

public partial class MainPage : ContentPage
{
	public List<string> ImageList1 { get; set; }
    public List<string> ImageList2 { get; set; }
    public List<string> ImageList3 { get; set; }
    public List<string> ImageList4 { get; set; }

    private List<string> _allImages;

    public MainPage()
	{
		InitializeComponent();

        GenerateData();
        ImageList1 = _allImages;
        ImageList2 = _allImages;
        ImageList3 = _allImages;
        ImageList4 = _allImages;

        BindingContext = this;
	}

    private void GenerateData()
    {
        _allImages = new();

        for(int i = 1; i <= 20; i++) 
        {
            _allImages.Add($"img{i.ToString("00")}.jpg");
        }
    }
}

