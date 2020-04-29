<?php
	$conn = mysqli_connect("localhost", "root", "");
	if (!$conn) {
		die('Could not connect: ' . mysqli_error());
	}
	mysqli_select_db($conn, "food") or die("Cannot connect to database");

	$type = $_GET['type'];

	$query = "SELECT * FROM recipe WHERE type='$type'";
	// $query = "SELECT * FROM recipe WHERE type='$type'";
	$resultSet = mysqli_query($conn, $query);

	if (!$resultSet) {
    printf("Error: %s\n", mysqli_error($conn));
    exit();
}

	print "<table border = '1'>
			<tr>
			<th>ID</th>
			<th>Author</th>
			<th>Name</th>
			<th>Type</th>
			<th>Description</th>
			</tr>";

	while ($row = mysqli_fetch_array($resultSet)) {
		echo "<tr>";
		echo "<td>" . $row['id'] . "</td>";
		echo "<td>" . $row['author'] . "</td>";
		echo "<td>" . $row['name'] . "</td>";
		echo "<td>" . $row['type'] . "</td>";
		echo "<td>" . $row['description'] . "</td>";
		echo "</tr>";
	}
	print "</table>";
	mysqli_close($conn);
?>