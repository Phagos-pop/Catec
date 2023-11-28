using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;

namespace CatWalk
{
    public class СatWalkSimulation : MonoBehaviour
    {
        private float TICK_COOLDOWN = 0.01f;
        private float SPEED = 0.1f;

        [SerializeField] private CatFoot _catFootPrefab;
        [SerializeField] private List<CatWalkPoint> _catWalkPoints;
        [SerializeField] private float _t;

        private CatFoot _catFoot;
        
        private float _Next_t;
        private int _pointCounter;
        private int _firstPoint;
        private int _secondPoint;
        private int _thirdPoint;
        private int _fourthPoint;

        private TimeSpan _timeFromLastTick => DateTime.Now - _lastTick;
        private DateTime _lastTick;

        private void Start()
        {
            _catFoot = Instantiate(_catFootPrefab, _catWalkPoints[0].Position, Quaternion.identity);
            _pointCounter = 0;
        }

        private void Update()
        {
            Tick();
            //_t = Mathf.Lerp(_t, _Next_t, SPEED);

            //_catFoot.transform.position = BezierCurve.GetPoint(
            //    _catWalkPoints[_firstPoint].Position,
            //    _catWalkPoints[_secondPoint].Position,
            //    _catWalkPoints[_thirdPoint].Position,
            //    _catWalkPoints[_fourthPoint].Position, _t);

            //_catFoot.transform.LookAt(BezierCurve.GetPoint(
            //    _catWalkPoints[_firstPoint].Position,
            //    _catWalkPoints[_secondPoint].Position,
            //    _catWalkPoints[_thirdPoint].Position,
            //    _catWalkPoints[_fourthPoint].Position, _t + 0.01f));

            //Tick();
        }

        private void Tick()
        {
            if (_timeFromLastTick > TimeSpan.FromSeconds(_t))
            {
                _catFoot.transform.LookAt(_catWalkPoints[SetLockPoint()].Position);
                _catFoot.transform.position = _catWalkPoints[SetPoint()].Position;
                _lastTick = DateTime.Now;
                _catFoot.NextHand();
                //if (_t < 1f)
                //{
                //    _Next_t += 0.005f;
                //}
                //else
                //{
                //    SetPoints();
                //    _t = 0;
                //    _Next_t = 0;
                //}
            }
        }

        private void SetPoints()
        {
            _firstPoint = _fourthPoint;
            _secondPoint = SetPoint();
            _thirdPoint = SetPoint();
            _fourthPoint = SetPoint();
        }

        private void SetInitPoints()
        {
            _firstPoint = 0;
            _secondPoint = SetPoint();
            _thirdPoint = SetPoint();
            _fourthPoint = SetPoint();
        }

        private int SetPoint()
        {
            if (_catWalkPoints.Count > _pointCounter)
            {
                _pointCounter++;
                return _pointCounter - 1;
            }
            _pointCounter = 0;
            return _pointCounter;
        }

        private int SetLockPoint()
        {
            if (_catWalkPoints.Count > _pointCounter + 1)
            {
                return _pointCounter + 1;
            }
            _pointCounter = 0;
            return _pointCounter;
        }
    }
}