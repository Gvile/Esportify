using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class SingleEventBase : ComponentBase
{
    #region Statements

    [Parameter] public int Id { get; set; }

    #endregion
}