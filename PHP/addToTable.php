<?php
	$conn = mysqli_connect("localhost", "root", "");
	if (!$conn) {
		die('Could not connect: ' . mysqli_error());
	}
	mysqli_select_db($conn, "food") or die("Cannot connect to database");

	$author = $_GET['author'];
	$name = $_GET['name'];
	$type = $_GET['type'];
	$description = $_GET['description'];

	mysqli_query($conn, "INSERT INTO recipe(author, name, type, description) VALUES ('$author', '$name', '$type', '$description')");
	mysqli_close($conn);
?>