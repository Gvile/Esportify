using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class CarouselBase : ComponentBase
{
    #region Statements

    [Parameter] public List<string> Images { get; set; } = new();
    
    protected int CurrentIndex;

    #endregion

    #region Methods

    protected void NextSlide()
    {
        CurrentIndex = (CurrentIndex + 1) % Images.Count;
    }

    protected void PreviousSlide()
    {
        CurrentIndex = (CurrentIndex - 1 + Images.Count) % Images.Count;
    }

    #endregion
}