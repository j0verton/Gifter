import React, { useEffect, useState } from 'react';

const PostList = () => {
    const [posts, setPosts] = useState([])

    useEffect(() => {
        fetch('/api/post')
            .then(res => res.json())
            .then(data => setPosts(data))

    }, []);

    return (
        <div>
            {posts.map((post) => (
                <div key={post.id}>
                    <img src={post.imageUrl} alt={post.title} />
                    <p>
                        <strong>{post.title}</strong>
                    </p>
                    <p>{post.caption}</p>
                </div>
            ))}
        </div>
    );
};
export default PostList;