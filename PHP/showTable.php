<?php
	$conn = mysqli_connect("localhost", "root", "");
	if (!$conn) {
		die('Could not connect: ' . mysqli_error());
	}
	mysqli_select_db($conn, "food") or die("Cannot connect to database");
	$resultSet = mysqli_query($conn, "SELECT * FROM `recipe`");

	echo "<table border = '1'>
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
	echo "</table>";
	mysqli_close($conn);
?>