public class Inimigo
{
    Imagem ImagemView;
    public Inimigo (Imagem a)
    }
    ImagemView = a;
    
    public void MoveX (double s)
    {
      ImageView.TranslationX-=s;
    } 
    public double GetX()
    {
        return ImageView.TranslationX;
    }
    public void Reset()
    {
        ImageView.TranslationX = 500;
    }
    public class Inimigos
    {
        List<Inimigo>Inimigo=new List<Inimigo>();
        Inimigo atual=null;
        double minX=0;
        public Inimigos(double a )
    }