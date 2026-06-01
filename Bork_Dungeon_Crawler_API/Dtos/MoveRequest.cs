using System;

public class MoveRequest
{

    // Id för spelaren som skall flyttas. Så alla states hålls separerade
    public int CharacterId { get; set; }

    // Riktningen spelarn går i. Hur man förflyttas mellan rummen
    public string Direction { get; set; } = "";
}
