<?php

$conn = "";

try {
    $servername = "admin_db";
    $dbname = "phpMYSQL";
    $username = "root";
    $password = "example";

    $conn = new PDO(
        "mysql:host=$servername; dbname=phpMYSQL",
        $username, $password
    );

    $conn->setAttribute(PDO::ATTR_ERRMODE,
        PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e) {
    echo "Connection failed: " . $e->getMessage();
}

?>