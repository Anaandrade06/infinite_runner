public class Animacao
{
    protected List<String> Animacao01 = new List<String>();
    protected List<String> Animacao02 = new List<String>();
    protected List<String> Animacao03 = new List<String>();
    public bool Loop = true;
    protected int AnimacaoTadalla = 1;
    bool Brush = true;
    int MainFrame = 1;
    protected Image compImagem;
    public Animacao(Image imagem)
    {
        compImagem = imagem;
    }
    public void Stop()
    {
        Brush = true;
    }
    public void Play()
    {
        Brush = false;
    }
    public void SetAnimationTadalla(int A)
    {
        AnimacaoTadalla = A;
    }
    public void Drawn()
    {
        if (Brush)
            return;
        string NomeArquivo = "";
        int AnimationHeigth = 0;
        if (AnimacaoTadalla == 1)
        {
            NomeArquivo = Animacao01[MainFrame];
            AnimationHeigth = Animacao01.Count;
        }
        else if (AnimacaoTadalla == 2)
        {
            NomeArquivo = Animacao02[MainFrame];
            AnimationHeigth = Animacao02.Count;
        }
        else if (AnimacaoTadalla == 3)
        {
            NomeArquivo = Animacao03[MainFrame];
            AnimationHeigth = Animacao03.Count;
        }
        compImagem.Source = ImageSource.FromFile(NomeArquivo);
        MainFrame++;
        if (MainFrame >= AnimationHeigth)
        {
            if (Loop)
                MainFrame = 0;
            else
            {
                Brush = true;
                OnStop();
            }
        }
    }
    public virtual void OnStop()
    {

    }
}