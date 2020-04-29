<?php
	$conn = mysqli_connect("localhost", "root", "");
	if (!$conn) {
		die('Could not connect: ' . mysqli_error());
	}
	mysqli_select_db($conn, "food") or die("Cannot connect to database");

	$id = $_GET['id'];
	$author = $_GET['author'];
	$name = $_GET['name'];
	$type = $_GET['type'];
	$description = $_GET['description'];

	$query = "UPDATE recipe SET author='$author', name='$name', type='$type', description='$description' WHERE id='$id'";
	mysqli_query($conn, $query);
	mysqli_close($conn);
?>