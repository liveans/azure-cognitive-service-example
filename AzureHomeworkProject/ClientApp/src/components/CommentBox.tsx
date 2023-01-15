import moment from 'moment';
import React from 'react';

interface CommentBoxProps {
    comment: string
    name: string
    language: string
    createdAt: Date
}

export const CommentBox = (props: CommentBoxProps) => {
    // Create a box to show a comment and username of the comment
    const { comment, name, language, createdAt } = props;
    return (
        <div className="bg-gray-600 p-4 rounded-lg flex grow-0 font-sans flex-col">
            <p className="font-bold text-base mb-2">{name}</p>
            <p className="mb-1">{comment}</p>
            <div className="flex flex-row mt-2 gap-1 text-sm">
                <p>{"Language:"}</p>
                <p className="font-bold">{language}</p>
            </div>
            <p className="text-xs">{moment(createdAt).format("MMMM Do YYYY, h:mm:ss a")}</p>
        </div>
    );
};