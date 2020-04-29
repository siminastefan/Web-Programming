<?php
	$conn = mysqli_connect("localhost", "root", "");
	if (!$conn) {
		die('Could not connect: ' . mysqli_error());
	}
	mysqli_select_db($conn, "food") or die("Cannot connect to database");

	$id = $_GET['id'];

	$query = "DELETE FROM recipe where id='$id'";
	$resultSet = mysqli_query($conn, $query);
	mysqli_close($conn);
?>