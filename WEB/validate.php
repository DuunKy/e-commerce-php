<?php

include_once('connection.php');

if ($_SERVER["REQUEST_METHOD"] == "POST") {

    $username = $_POST["username"];
    $password = $_POST["password"];
    $stmt = $conn->prepare("SELECT * FROM adminlogin WHERE username_admin=? AND password_admin=?");
    $stmt->bindParam(1, $username, PDO::PARAM_STR); // Forces input to be a string
    $stmt->bindParam(2, $password, PDO::PARAM_STR); // Forces input to be a string
    $stmt->execute();
    $user = $stmt->fetchObject(); // To not fetchAll()

    if ($user) { // If user is full
        header("location: adminpage.php"); // Uses adminpage.php
    }
    else {
        echo "<script>";
        echo "alert('WRONG INFORMATION')";
        echo "</script>";
        die();
    }
}