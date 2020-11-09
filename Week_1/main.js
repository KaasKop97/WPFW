// HEADER

function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
  }

  window.onclick = function(e) {
    if (!e.target.matches('.dropbtn')) {
    var myDropdown = document.getElementById("myDropdown");
      if (myDropdown.classList.contains('show')) {
        myDropdown.classList.remove('show');
      }
    }
  }

  window.onscroll = function() {scrollFunction()};

  function scrollFunction() {
      if (document.body.scrollTop > 30 || document.documentElement.scrollTop > 30) {
          document.getElementById("navbar").style.padding = "5px 10px";
      } else {
          document.getElementById("navbar").style.padding = "15px 10px";
      }
  }

// INTERACTIE

function addNewComment() {
    let comment = document.getElementById("new_comment_text");
    let comment_section = document.getElementById("comment_section");

    let new_comment = document.createElement("div");
    new_comment.classList = "comment";
    let avatar = document.createElement("img");
    avatar.src = "https://avatars3.githubusercontent.com/u/15621524?s=88&u=60f715943a86e0d3dc8074ad8b4ff7e85937f60e&v=4"
    let avatar_div = document.createElement("div");
    avatar_div.classList = "avatar";
    avatar_div.append(avatar);
    new_comment.append(avatar_div);

    let message = document.createElement("div");
    message.classList = "message"

    let message_header = document.createElement("div")
    message_header.classList = "message_header";

    let actual_header = document.createElement("p");
    actual_header.innerText = "Jan commented 1 minutes ago"

    message_header.append(actual_header)
    message.append(message_header)
    new_comment.append(message)

    let message_content = document.createElement("div");
    let actual_comment = document.createElement("p");
    actual_comment.className="message_content";
    actual_comment.innerText = comment.value;
    message.append(actual_comment)

    new_comment.append(message_content);

    comment_section.append(new_comment);
}