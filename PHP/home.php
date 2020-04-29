<!DOCTYPE html>
<html>
<head>
	<title></title>
	<script type="text/javascript">
		var xmlhttp;
		function getRecipes() {
			xmlhttp = GetXmlHttpObject();
			if (xmlhttp == null) {
				alert("Your browser does not support XMLHTTP!");
				return;
			}
			var url = "showTable.php";
			xmlhttp.onreadystatechange = stateChanged;
			xmlhttp.open("GET", url, true);
			xmlhttp.send(null);
		}
		function addRecipe() {
			xmlhttp = GetXmlHttpObject();
			if (xmlhttp == null) {
				alert("Your browser does not support XMLHTTP!");
				return;
			}
			var url = "addToTable.php";
			var params = "author=" + document.getElementById("author").value + "&" +
						"name=" + document.getElementById("name").value + "&" +
						"type=" + document.getElementById("type").value + "&" +
						"description=" + document.getElementById("description").value;
			xmlhttp.onreadystatechange = stateChanged;
			xmlhttp.open("GET", url + "?" + params, true);
			xmlhttp.send(null);
		}
		function updateRecipe() {
			xmlhttp = GetXmlHttpObject();
			if (xmlhttp == null) {
				alert("Your browser does not support XMLHTTP!");
				return;
			}
			var url = "updateToTable.php";
			var params = "id=" + document.getElementById("id").value + "&" +
						"author=" + document.getElementById("author").value + "&" +
						"name=" + document.getElementById("name").value + "&" +
						"type=" + document.getElementById("type").value + "&" +
						"description=" + document.getElementById("description").value;
			xmlhttp.onreadystatechange = stateChanged;
			xmlhttp.open("GET", url + "?" + params, true);
			xmlhttp.send(null);
		}
		function deleteRecipe() {
			xmlhttp = GetXmlHttpObject();
			if (xmlhttp == null) {
				alert("Your browser does not support XMLHTTP!");
				return;
			}
			var url = "deleteFromTable.php";
			var params = "id=" + document.getElementById("id").value;
			xmlhttp.onreadystatechange = stateChanged;
			xmlhttp.open("GET", url + "?" + params, true);
			xmlhttp.send(null);
		}
		function browseRecipe(str) {
			if (str == "") {
				document.getElementById("maindiv").innerHTML = "";
				return;
			}
			alert(str);
			var url = "browseTable.php";
			var params = "type=" + str;
			xmlhttp = GetXmlHttpObject();
			xmlhttp.onreadystatechange = stateChanged;
			xmlhttp.open("GET", url + "?" + params, true);
			xmlhttp.send(null);

		}
		function stateChanged() {
			if (xmlhttp.readyState == 4) {
				// alert(xmlhttp.responseText);
				document.getElementById("maindiv").innerHTML = xmlhttp.responseText;
			}
		}
		function GetXmlHttpObject() {
			 // code for IE7+, Firefox, Chrome, Opera, Safari
			if (window.XMLHttpRequest) {
				return new XMLHttpRequest();
			}
			// code for IE6, IE5
			if (window.ActiveXObject) {
				return new ActiveXObject("Microsoft.XMLHTTP");
			}
			return null;
		}
	</script>
</head>

<body>
	<?php
	session_start(); // starts the session
	if ($_SESSION['user']) {
		//checks if user is logged on
	} else {
		header("location: index.php"); //redirects if user is not logged on
	}

	$user = $_SESSION['user']; // assigns user value
	?>
	
	<h2>Home Page</h2>
	<p>Hello <?php print "$user" ?></p> <!--display users' name -->
	<a href="logout.php">Log out</a> <br><br>
	<form>
		<label for="id">ID:</label>
		<input type="text" id="id" name="id">
		<br><br>

		<label for="author">Author:</label>
		<input type="text" id="author" name="author">
		<br><br>

		<label for="name">Name:</label>
		<input type="text" id="name" name="name">
		<br><br>

		<label for="type">Type:</label>
		<input type="text" id="type" name="type">
		<br><br>

		<label for="description">Description:</label>
		<input type="text" id="description" name="description">
		<br><br>

		<label>Choose a type:</label>
		<select id="list" name="list" onchange="browseRecipe(this.value)">
			<option value="">Select a type</option>
			<option value="Breakfast">Breakfast</option>
			<option value="Desert">Desert</option>
			<option value="Main">Main</option>
			<option value="Soup">Soup</option>
			<option value="Appetizer">Appetizer</option>
		</select>

		<input type="button" value="Add" onclick="addRecipe()"/>
		<input type="button" value="Delete" onclick="deleteRecipe()"/>
		<input type="button" value="Update" onclick="updateRecipe()"/>
		<input type="button" value="Show Recipes" onclick="getRecipes()" />
	</form>
	<br>
	<br>
	<div id="maindiv"></div>
</body>
</html>