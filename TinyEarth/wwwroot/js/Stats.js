async function fetchPlayerStats(playerName) {
    const statusElement = document.getElementById("player-stats");

    try {
        const res = await fetch(`http://plan.tiny-earth.com:25569/docs/players/${playerName}/stats`);
        if (!res.ok) {
            throw new Error("Spillerdata kunne ikke hentes.");
        }

        const data = await res.json();
        const playTime = data.playTime;  // Eksempel på data
        const kills = data.kills;       // Eksempel på data

        statusElement.innerHTML = `
            Spiller: ${playerName}<br>
            Spilletid: ${playTime} timer<br>
            Kills: ${kills}
        `;
    } catch (error) {
        console.error('Fejl ved hentning af spillerdata: ', error);
        statusElement.innerText = 'Kunne ikke hente spillerdata.';
    }
}

// Kald funktionen for at vise stats for en spiller (f.eks. "PlayerName")
fetchPlayerStats('PlayerName');
