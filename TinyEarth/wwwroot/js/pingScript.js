

/*fetch('https://api.mcstatus.io/v2/status/java/88.99.142.85:25565') 
        .then(res => res.json())
        .then(data => {
            const playersOnline = data.players.online;
            const maxPlayers = data.players.max;
            document.getElementById("mc-status").innerText = `${playersOnline} / ${maxPlayers}`;
        })
        .catch(error => {
            console.error('Couldnt fetch server status: ', error);
        });*/

function fetchMCStatus() {
    fetch('https://api.mcstatus.io/v2/status/java/88.99.142.85:25565')
        .then(res => res.json())
        .then(data => {
            const playersOnline = data.players.online;
            const maxPlayers = data.players.max;
            document.getElementById("mc-status").innerText = `${playersOnline} / ${maxPlayers}`;
        })
        .catch(error => {
            console.error('Couldnt fetch server status: ', error);
            document.getElementById("mc-status").innerText = 'Server unreachable';  // Vist fejlinformation
        });
}


setInterval(fetchMCStatus, 30000);  // 30000 millisekunder = 30 sekunder

// Kald funktionen første gang når siden indlæses
fetchMCStatus();
