

async function GetAllUser(){
    const AllUsers=await fetch('https://localhost:7062/api/UserProfile');
    let DataRuslt=await AllUsers.json();
    console.log(DataRuslt.data)
    let output='';
   
    DataRuslt.data.forEach(element => {
        let DateFormat=new Date(element.dateOfBirth)
        output+=`<div class="col-md-4 card"  >
                <img src="./client-sm-3.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Name User:${element.fristName + element.lastName}</h5>
                    <p class="card-text">email User:${element.userID}</p>
                    <p class="card-text">email User:${element.email}</p>
                    <p class="card-text">Date Of Birth:${new Date(element.dateOfBirth).toLocaleDateString()}</p>
                    <button class="btn btn-success" onclick="editUser(${element.userID})">Edit</button>
                    <button class="btn btn-danger" onclick="deleteUser(${element.userID})">Delete</button>
                    <a href="./post.html?userID=${element.userID}" class="btn btn-primary">Posts</a>
                  </div>
              </div>`
    });
    document.getElementById('CardDisplay').innerHTML=output              
    
    
}
GetAllUser();
function Open(){
   
var Form=document.getElementById("FormAddUser");
var btnClose=document.getElementById("OpenCloseUser");
 var btnOpen=document.getElementById("OpenAddUser");
 Form.classList.remove("d-none");
 btnClose.classList.remove("d-none");
btnOpen.classList.add("d-none")


}
function Close(){
    var btnClose=document.getElementById("OpenCloseUser");
    var Form=document.getElementById("FormAddUser");
    var btnOpen=document.getElementById("OpenAddUser");
    btnClose.classList.add("d-none");
    Form.classList.add("d-none");
    btnOpen.classList.remove("d-none")

}
function validateUserInput(firstName, lastName, email) {
 
    if (firstName.length < 3 || firstName.length > 12) {
        alert("First name is required and must be between 3 and 12 characters.");
        return false;
    }

    
    if (lastName.length < 3 || lastName.length > 12) {
        alert("Last name is required and must be between 3 and 12 characters.");
        return false;
    }

    
    const emailTest = /^[A-Za-z\d._%+-]+@[A-Za-z\d.-]+\.[A-Za-z]{2,}$/;
    if (!email || !emailTest.test(email)) {
        alert("Please enter a valid email address.");
        return false;
    }

    return true;
}

 async function addUser() {
   
    const FirstName = document.getElementById("firstName").value;
    const LastName = document.getElementById("lastName").value;
    const Email = document.getElementById("email").value;
    const DateOfBirth = document.getElementById("dateOfBirth").value;
    const userData = {
        fristName: FirstName,
        lastName: LastName,
        email: Email,
        dateOfBirth: DateOfBirth
    };

debugger  

    
try {
   if(validateUserInput(FirstName, LastName, Email)){

       const response = await fetch('https://localhost:7062/api/UserProfile/AddUser', {
           method: 'POST',  
           headers: {
               'Content-Type': 'application/json;charset=UTF-8'  
           },
           body: JSON.stringify(userData)  
       });
   
      
       if (!response.ok) {
           const errorData =await  response.json();  
           console.error("Error adding post:", errorData);  
           return;
       }
   
   
       const data = await response.json(); 
      if(data.status){
      
           alert("Add Users successfully!");
           document.getElementById("addUserForm").reset()
           GetAllUser(); 
       } else {
           alert("Failed to add Post.");
       }
       
   }
} catch (error) {
    
    console.error("Error occurred while adding post:", error);  
}
}      

 async function editUser(userId) {
  
    console.log(userId)
    const newFirstName = prompt("Enter new first name:");
    const newLastName = prompt("Enter new last name:");
    const newEmail = prompt("Enter new email:");
    // const newdateOfBirth = prompt("Enter new email:");
    
    const userData = {
        fristName: newFirstName,
        lastName: newLastName,
        email: newEmail,
        // dateOfBirth: newdateOfBirth
    };
debugger;
    
        const response = await fetch(`https://localhost:7062/api/UserProfile/${userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify(userData)
        });
        var x=await response.json();

        console.log(x)
        if (x.status==200) {
            alert("User Update successfully!");
            GetAllUser(); 
        } else {
            alert("Failed to add Post.");
        }
    
}

async function deleteUser(userId) {
    if (confirm("Are you sure you want to delete this user?")) {
        await fetch(`https://localhost:7062/api/UserProfile/${userId}`, {
            method: 'DELETE'
        });
        GetAllUser();
    }}