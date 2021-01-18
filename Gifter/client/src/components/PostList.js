import React, { useEffect, useState, useContext } from 'react';
import Post from './Post'
import { UserProfileContext } from "../providers/UserProfileProvider";


const PostList = () => {
    const [posts, setPosts] = useState(null)
    const { getToken } = useContext(UserProfileContext);

    useEffect(() => {
        getToken().then((token) =>
            fetch('/api/post', {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}` // The token gets added to the Authorization header
                }
            })
        )
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