namespace SlantedView;

public partial class Flexy : ContentPage
{
    public List<string> ImageList { get; set; }

    public Flexy()
	{
		InitializeComponent();
        GenerateData();

        //ImageList.ForEach(i => flexlayout.Add(new Image() { Source = i }));
	}

    private void GenerateData()
    {
        ImageList = new();

        for (int i = 1; i <= 2; i++)
        {
            ImageList.Add($"img{i.ToString("00")}.jpg");
        }
    }
}