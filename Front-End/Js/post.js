function getUserIdFromUrl() {
    const params = new URLSearchParams(window.location.search);
    return params.get('userID');
}


async function fetchUserPosts() {
    const userId = getUserIdFromUrl(); 
    if (!userId) {
        document.getElementById('userPosts').innerHTML = "User ID not found";
        return;
    }

    const response = await fetch(`https://localhost:7062/api/Post/GetPostByIdUser?id=${userId}`);
    const posts = await response.json();
console.log(posts)
    let output = '';
    posts.data.forEach(post => {
        output += `
             <tr>
                <th scope="row">1</th>
                <td>${post.title}</td>
                <td>${post.content}</td>
                <td>${post.userName}</td>
                <td>${new Date(post.datedPost).toLocaleDateString()}</td>
                <td><button class="btn btn-success" onclick="editPost(${post.postID})" >Edit</button></td>
              <td><button class="btn btn-danger"onclick="deletePost(${post.postID})" >Delete</button></td>
              </tr>
            `;
        });
        

    document.getElementById('userPosts').innerHTML = output;
}
fetchUserPosts();
function Open(){
   
    var Form=document.getElementById("FormAddPost");
    var btnClose=document.getElementById("OpenCloseUser");
     var btnOpen=document.getElementById("OpenAddUser");
     Form.classList.remove("d-none");
     btnClose.classList.remove("d-none");
    btnOpen.classList.add("d-none")
    
    
    }
    function Close(){
        var btnClose=document.getElementById("OpenCloseUser");
        var Form=document.getElementById("FormAddPost");
        var btnOpen=document.getElementById("OpenAddUser");
        btnClose.classList.add("d-none");
        Form.classList.add("d-none");
        btnOpen.classList.remove("d-none")
    
    }
async function editPost(postId) {
  
    console.log(postId)
    const TItle = prompt("Enter new TITle Post:");
    const Content = prompt("Enter new Content Post:");
    
  
    
    const userData = {
        title: TItle,
        content: Content,
      
    };
debugger;
    
        const response = await fetch(`https://localhost:7062/api/Post/${postId}`, {
            method: 'PUT',
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify(userData)
        });
        var x=await response.json();

        console.log(x)
        if (x.status==200) {
            alert("Post Update successfully!");
            fetchUserPosts(); 
        } else {
            alert("Failed to Update Post.");
        }
    
}
async function deletePost(userId) {
    if (confirm("Are you sure you want to delete this Post?")) {
        await fetch(`https://localhost:7062/api/Post/${userId}`, {
            method: 'DELETE'
        });
        fetchUserPosts();
    }}

   async function addPost() {
   
        const TITle = document.getElementById("title").value;
        const Content = document.getElementById("content").value;
        const UserId = getUserIdFromUrl();
        
    console.log(UserId)
        
        const PostData = {
            title: TITle,
            content: Content,
            userID: UserId

        };
    debugger
        try {
   
            const response = await fetch('https://localhost:7062/api/Post/AddPost', {
                method: 'POST',  
                headers: {
                    'Content-Type': 'application/json;charset=UTF-8'  
                },
                body: JSON.stringify(PostData)  
            });
        
           
            if (!response.ok) {
                const errorData =await  response.json();  
                console.error("Error adding post:", errorData);  
                return;
            }
        
        
            const data = await response.json(); 
           if(data.status){
           
                alert("Add Post successfully!");
                fetchUserPosts(); 
                document.getElementById("FormAddPost").reset()
            } else {
                alert("Failed to add Post.");
            }
            
        } catch (error) {
            
            console.error("Error occurred while adding post:", error);  
        }
        
    }