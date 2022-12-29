namespace SlantedView;

public partial class MainPage : ContentPage
{
	public List<string> ImageList1 { get; set; }
    public List<string> ImageList2 { get; set; }
    public List<string> ImageList3 { get; set; }
    public List<string> ImageList4 { get; set; }

    private List<string> _allImages;

    private Random _random = new();

    private bool animate = false;

    public MainPage()
	{
		InitializeComponent();

        GenerateData();
        ImageList1 = Randomize(_allImages);
        ImageList2 = Randomize(_allImages);
        ImageList3 = Randomize(_allImages);
        ImageList4 = Randomize(_allImages);

        BindingContext = this;

        grid1.Loaded += Grid_LoadedAsync_left;
        grid2.Loaded += Grid_LoadedAsync_right;
        grid3.Loaded += Grid_LoadedAsync_left;
        grid4.Loaded += Grid_LoadedAsync_right;

        grid1.Unloaded += (s,e) => animate = false;
        grid2.Unloaded += (s, e) => animate = false;
        grid3.Unloaded += (s, e) => animate = false;
        grid4.Unloaded += (s, e) => animate = false;
    }

    private async void Grid_LoadedAsync_left(object sender, EventArgs e)
    {
        animate = true;
        await AnimateAsync((CollectionView)sender, 1);
    }

    private async void Grid_LoadedAsync_right(object sender, EventArgs e)
    {
        animate = true;
        await AnimateAsync((CollectionView)sender, -1);
    }

    private async Task AnimateAsync(CollectionView grid, int direction)
    {
        if(animate)
        {
            await grid.TranslateTo(-1000*direction, 0, 12000);
            await grid.TranslateTo(1000*direction, 0, 24000);
            await grid.TranslateTo(0, 0, 12000);

            await AnimateAsync(grid, direction);
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