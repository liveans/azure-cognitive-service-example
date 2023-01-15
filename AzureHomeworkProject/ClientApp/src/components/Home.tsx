import React, { Component } from 'react';
import { CommentBox } from './CommentBox.tsx';
import axios from "axios";
import { Button } from './Button.tsx';

// Create a new component called Home as Function component

interface CommentModel {
  id: string;
  name: string;
  comment: string;
  language: string;
  iSOName: string;
  createdAt: Date;
}

export const Home = () => {
  const [comments, setComments] = React.useState([]);
  const [languages, setLanguages] = React.useState([]);
  const [selectedLanguage, setSelectedLanguage] = React.useState('All');
  React.useEffect(() => {
    axios.get('api/comments')
      .then((response) => {
        console.log(response.data.comments);
        setComments(response.data.comments);
        const tempMap = new Map();
        response.data.comments.forEach(element => {
          console.log(element.isoName, element.language);
          tempMap.set(element.isoName, element.language);
        });
        const tempArray: any[] = []
        tempMap.forEach((value, key) => {
          const data = {isoName: key, language: value};
          tempArray.unshift(data);
        });
        setLanguages(tempArray);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  React.useEffect(() => {
    axios.get(selectedLanguage === 'All' ? 'api/comments/' : 'api/comments/list/'+selectedLanguage)
      .then((response) => {
        console.log(response.data.comments);
        setComments(response.data.comments);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [selectedLanguage]);
  return (
    <div className="flex flex-1 flex-col text-white container">
      <div className="grid grid-cols-6 mb-6 gap-4">
        <Button title='All' onClick={() => { setSelectedLanguage("All"); }} active={selectedLanguage === 'All'} />
        {languages.map(({ language, isoName }: { language: string, isoName: string }) => <Button key={language} title={language} onClick={() => { setSelectedLanguage(isoName); }} active={selectedLanguage === isoName} />)}
      </div>
      <div className="grid grid-cols-3 gap-4">
        {comments.map(({ id, comment, name, language, createdAt }: CommentModel) => <CommentBox key={id.toString()} comment={comment} name={name} language={language} createdAt={createdAt} />)}
      </div>
    </div>
  );
}
