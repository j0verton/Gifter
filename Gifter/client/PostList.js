import { useEffect, useState } from "react"
import React, { useEffect, useState } from 'react';

const PostList = () = {
    const [posts, setPosts] = useState([])

}

useEffect(() => {
    fetch('/api/posts')
        .then(res => res.json)
        .then(data => setPosts(data))

}, [])