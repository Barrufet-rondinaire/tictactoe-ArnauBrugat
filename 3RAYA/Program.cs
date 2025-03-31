using System.Net.Http.Json;
using System.Text.RegularExpressions;

string DeterminarGuanyador(string tauler)
    {
        string[] linies = new string[8];
        
        // Horitzontals
        linies[0] = tauler.Substring(0, 3);
        linies[1] = tauler.Substring(3, 3);
        linies[2] = tauler.Substring(6, 3);

        // Verticals
        linies[3] = "" + tauler[0] + tauler[3] + tauler[6];
        linies[4] = "" + tauler[1] + tauler[4] + tauler[7];
        linies[5] = "" + tauler[2] + tauler[5] + tauler[8];

        // Diagonals
        linies[6] = "" + tauler[0] + tauler[4] + tauler[8];
        linies[7] = "" + tauler[2] + tauler[4] + tauler[6];

        // Revisem les línies per veure si alguna té 3 fitxes iguals
        foreach (var linia in linies)
        {
            if (Regex.IsMatch(linia, @"^000$"))
                return "Jugador 1";
            if (Regex.IsMatch(linia, @"^XXX$"))
                return "Jugador 2";
        }

        return "Empat";
    }
private static readonly HttpClient client = new HttpClient();
async Task<List<Partida>> GetPartidesAsync(){
    for (int i = 1; i <= 10000; i++)
    {
        string url = $"http://localhost:8080/partida/{i}";
        string ObtenerUrlPartida(i) = url;
    }
    var response = await client.GetStringAsync(url);
    var partides = JsonConvert.DeserializeObject<List<Partida>>(response);
    return partides;
}
async Task<List<Jugador>> ObtenirParticipantAsync()
    {
        string url = "http://localhost:8080/jugadors";
        var response = await client.GetStringAsync(url);
        
        var regex = new Regex(@"/nom\s(?<nom>\w*\s\w\W*\S*)");
        var regex1 = new Regex (@"/nacionalitat\s(?<nacionalitat>repres[a-z]*\s[a-z]*\s([A-Z]*[a-z]*))")
        MatchCollection matches = regex.Matches(response);
        
        var participants = new List<Jugador>();
        foreach (Match match in matches)
        {
            if (match.Success)
            {
                string participantName = match.Groups["nom"].Value;
                string nacionalitat = match.Groups["nacionalitat"].Value;

                var jugador = new Jugador
                {
                    Nombre = participantName,
                    Nacionalitat = nacionalitat
                };

                participants.Add(jugador);
            }
        }

        return;
    }