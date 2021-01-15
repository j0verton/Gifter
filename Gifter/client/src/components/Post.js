import React from "react"
import { Card, CardBody, CardImg } from "reactstrap"
import { Link } from "react-router-dom";

const Post = ({ post }) => {
    return (
        <Card className="m-4">
            <p className="text-left px-2">Posted by:
                <Link to={`/post/${post.id}`}>{post.userProfile.name}</Link>
            </p>
            <CardImg top src={post.imageUrl} alt={post.title} />
            <CardBody>
                <p>
                    <Link to={`/posts/${post.id}`}>
                        <strong>{post.title}</strong>
                    </Link>
                </p>
                <p>{post.caption}</p>
            </CardBody>
        </Card>
    )
};
export default Post;