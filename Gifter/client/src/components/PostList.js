import React, { useEffect, useState } from 'react';
import Post from './Post'
const PostList = () => {
    const [posts, setPosts] = useState(null)

    useEffect(() => {
        fetch('/api/post')
            .then(res => res.json())
            .then(data => setPosts(data))

    }, []);

    if (posts === null) {
        return null
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="cards-column">
                    {posts.map((post) => (
                        <Post key={post.id} post={post} />
                    ))}
                </div>
            </div>
        </div>
    );
};
export default PostList;