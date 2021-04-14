public class Resolution
{
    public int width, height;

    public Resolution(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override string ToString()
    {
        return width.ToString() + "x" + height.ToString();
    }
}
