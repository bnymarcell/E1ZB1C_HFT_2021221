let companies = [];
let connection = null;
getdata();



function setupSignalR() {
     connection = signalR.HubConnectionBuilder()
        .withUrl("http://localhost:50212/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CompanyCreated", (user, message) => {
        console.log(user);
        console.log(message);
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}


async function getdata() {
    await fetch('http://localhost:50212/company')
        .then(x => x.json())
        .then(y => {
            companies = y;
            //console.log(companies);
            display();
        });
}


async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};



function display() {
    document.getElementById('resultarea').innerHTML = "";
    companies.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.company_id + "</td><td>" + t.company_name + "</td><td>" + `<button type="button" onclick="remove(${t.company_id})">Delete</button>` +"</td></tr> "
        console.log(t.company_name)
    });
}


 
function remove(id) {
    fetch('http://localhost:50212/company/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}


function create() {
    let name = document.getElementById('companyname').value;
    fetch('http://localhost:50212/company', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                company_name: name
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    
}