<html>
<head>
	<title></title>
</head>
<body>
	<h2>Registration Page</h2>
	<a href="index.php">Click here to go back</a><br>
	
	<form action="register.php" method="post">
		Enter Username: <input type="text" name="username" required="required"><br>
		Enter Password: <input type="password" name="password" required="srequired"><br>
		<input type="submit" name="Register">
	</form>
</body>
</html>

<?php
	if ($_SERVER["REQUEST_METHOD"] == "POST") {
		$conn = mysqli_connect("localhost", "root", "") or die(mysql_error()); // connect to server
		mysqli_select_db($conn, "food") or die("Cannot connect to database"); //connect to database
		
		$username = mysqli_real_escape_string($conn, $_POST['username']);
		$password = mysqli_real_escape_string($conn, $_POST['password']);
		$bool = TRUE;

		$query = mysqli_query($conn, "select * from users"); //query the users table
		while ($row = mysqli_fetch_array($query)) //display all rows from query
		{
			$table_users = $row['username']; // the first username row is passed on to $table_users, and so on until the query is finished
			if ($username == $table_users) //checks if there are any matching fields
			{
				$bool = FALSE; // sets bool to false
				print '<script>alert("Username has been taken!");</script>'; //promts the user
				print '<script>window.location.assign("register.php");</script>'; // redirects to register.php
			}
		}
		if ($bool) {
			mysqli_query($conn, "insert into users (username, password) values ('$username', '$password')"); // insert the value to table users
			print '<script>alert("Successfully Registered!");</script>'; //promts the user
				print '<script>window.location.assign("register.php");</script>'; // redirects to register.php
		}
}	
?>
