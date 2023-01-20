using System.Diagnostics.Metrics;

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

    private int counter = 0;

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

        grid1.Unloaded += (s, e) => animate = false;
        grid2.Unloaded += (s, e) => animate = false;
        grid3.Unloaded += (s, e) => animate = false;
        grid4.Unloaded += (s, e) => animate = false;
    }

    private void Grid_LoadedAsync_left(object sender, EventArgs e)
    {
        animate = true;
        AnimateAsync((CollectionView)sender, 1);
    }

    private void Grid_LoadedAsync_right(object sender, EventArgs e)
    {
        animate = true;
        AnimateAsync((CollectionView)sender, -1);
    }

    private void AnimateAsync(CollectionView grid, int direction)
    {
        //var parentAnimation = new Animation();

        //var animation_ab = new Animation(v => grid.TranslationX = v, -1000*direction, 1000*direction) ;
        //var animation_ba = new Animation(v => grid.TranslationX = v, 1000 * direction, -1000*direction);

        //parentAnimation.Add(0, 0.5, animation_ab);
        //parentAnimation.Add(0.5, 1, animation_ba);

        //parentAnimation.Commit(this, "Animation", length: 20000, repeat: () => animate);
        counter++;

        new Animation
        {
            {0, 0.5, new Animation (v => grid.TranslationX = v, -1000*direction, 1000*direction) },
            {0.5, 1, new Animation (v => grid.TranslationX = v, 1000*direction, -1000*direction) }
        }
        .Commit(this, $"Animation{counter}", length: 60000, repeat: () => animate);
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